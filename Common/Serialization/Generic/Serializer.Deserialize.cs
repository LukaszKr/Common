using System;
using System.Reflection;

namespace ProceduralLevel.Common.Serialization
{
	public static partial class Serializer
	{
		public static DataType Deserialize<DataType>(IObjectSerializer serializer, DataType instance = null) where DataType : class
		{
			return (DataType)Deserialize(typeof(DataType), serializer, instance);
		}

		public static object Deserialize(Type type, IObjectSerializer serializer, object instance = null)
		{
			if(serializer == null)
			{
				return null;
			}
			if(instance == null)
			{
				instance = Activator.CreateInstance(type);
			}
			IObjectSerializable serializable = instance as IObjectSerializable;
			if(serializable != null)
			{
				serializable.Deserialize(serializer);
			}
			else
			{
				FieldInfo[] fields = GetSerializableFields(type);
				int length = fields.Length;
				for(int x = 0; x < length; x++)
				{
					FieldInfo field = fields[x];
					DeserializeField(instance, field, serializer, null);
				}
			}
			return instance;
		}

		private static void DeserializeField(object obj, FieldInfo field, IObjectSerializer serializer, IArraySerializer arraySerializer)
		{
			Type fieldType = field.FieldType;
			TypeSerializer typeSerializer = GetTypeSerializer(fieldType);
			if(typeSerializer != null)
			{
				field.SetValue(obj, Convert.ChangeType(typeSerializer.Deserialize(fieldType, field.Name, serializer, arraySerializer), fieldType));
			}
		}
	}
}
