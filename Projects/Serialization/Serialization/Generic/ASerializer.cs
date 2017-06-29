using System;
using System.Collections.Generic;
using System.Reflection;

namespace ProceduralLevel.Serialization
{
	public abstract class ASerializer
    {
		public static List<TypeSerializer> Serializers = new List<TypeSerializer>();

		static ASerializer()
		{
			Serializers.Add(new PrimitiveSerializer());
			Serializers.Add(new ArraySerializer());
			Serializers.Add(new CollectionSerializer());
			Serializers.Add(new ClassSerializer());
		}

		protected ASerializer() { }

		public abstract void SerializeObject(object obj, AObject serializer);
		public abstract object DeserializeObject(Type type, AObject serializer, object instance = null);

		public DataType DeserializeObject<DataType>(AObject serializer, DataType instance = null) where DataType: class
		{
			return (DataType)DeserializeObject(typeof(DataType), serializer, instance);
		}

		public static TypeSerializer GetTypeSerializer(Type fieldType)
		{
			int count = Serializers.Count;
			for(int x = 0; x < count; x++)
			{
				TypeSerializer typeSerializer = Serializers[x];
				if(typeSerializer.CheckType(fieldType))
				{
					return typeSerializer;
				}
			}
			return null;
		}

		protected static FieldInfo[] GetSerializableFields(Type type)
		{
			FieldInfo[] fields;
			FieldInfo[] privateFields;
#if NET_CORE
			fields = type.GetTypeInfo().GetFields(BindingFlags.Public | BindingFlags.Instance);
			privateFields = type.GetTypeInfo().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
#else
			fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
			privateFields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
#endif
			int count = 0;
			int privateCount = 0;
			for(int x = 0; x < fields.Length; x++)
			{
				FieldInfo field = fields[x];
				if(!HasAttribute<NonSerializedFieldAttribute>(field))
				{
					count ++;
				}
				else
				{
					fields[x] = null;
				}
			}
			for(int x = 0; x < privateFields.Length; x++)
			{
				FieldInfo field = privateFields[x];

				if(HasAttribute<SerializedFieldAttribute>(field))
				{
					privateCount++;
				}
				else
				{
					privateFields[x] = null;
				}
			}
			if(count+privateCount > 0)
			{
				FieldInfo[] result = new FieldInfo[count+privateCount];

				int index = 0;
				for(int x = 0; x < fields.Length; x++)
				{
					FieldInfo field = fields[x];
					if(field != null)
					{
						result[index] = field;
						index ++;
					}
				}
				for(int x = 0; x < privateFields.Length; x++)
				{
					FieldInfo field = privateFields[x];
					if(field != null)
					{
						result[index] = field;
						index ++;
					}
				}
				return result;
			}
			return null;
		}

		protected static bool HasAttribute<Type>(FieldInfo field) where Type: Attribute
		{
#if NET_CORE
				return (field.GetCustomAttribute<Type>() != null);
#else
			return (field.GetCustomAttributes(typeof(Type), true).Length > 0);
#endif
		}
	}
}
