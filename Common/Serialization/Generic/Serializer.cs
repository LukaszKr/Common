using ProceduralLevel.Common.Helper;
using ProceduralLevel.Common.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ProceduralLevel.Common.Serialization
{
	public static partial class Serializer
    {
		public static List<TypeSerializer> Serializers = new List<TypeSerializer>();

		static Serializer()
		{
			Serializers.Add(new PrimitiveSerializer());
			Serializers.Add(new ArraySerializer());
			Serializers.Add(new CollectionSerializer());
			Serializers.Add(new ClassSerializer());
		}

		private static FieldInfo[] GetSerializableFields(Type type)
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
			for(int x = 0; x < privateFields.Length; x++)
			{
				FieldInfo field = privateFields[x];
				SerializableFieldAttribute attribute = null;
#if NET_CORE
				attribute = field.GetCustomAttribute<SerializableAttribute>();
#else
				SerializableFieldAttribute[] attributes = (SerializableFieldAttribute[])field.GetCustomAttributes(typeof(SerializableFieldAttribute), true);
				if(attributes.Length > 0)
				{
					attribute = attributes[0];
				}
#endif
				if(attribute != null)
				{
					count ++;
				}
				else
				{
					privateFields[x] = null;
				}
			}
			if(count > 0)
			{
				int index = fields.Length;
				fields = fields.Resize(fields.Length+count);
				for(int x = 0; x < privateFields.Length; x++)
				{
					FieldInfo field = privateFields[x];
					if(field != null)
					{
						fields[index] = field;
						index ++;
					}
				}
			}

			return fields;
		}
	}
}
