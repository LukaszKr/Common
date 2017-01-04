using System;
using System.Reflection;

namespace ProceduralLevel.Common.Serialization
{
	public static partial class Serializer
	{
		public static DataType Deserialize<DataType>(IObjectSerializer serializer) where DataType : class
		{
			return (DataType)Deserialize(typeof(DataType), serializer);
		}

		public static object Deserialize(Type type, IObjectSerializer serializer)
		{
			if(serializer == null)
			{
				return null;
			}
			object obj = Activator.CreateInstance(type);
			FieldInfo[] fields = GetSerializableFields(type);
			int length = fields.Length;
			for(int x = 0; x < length; x++)
			{
				FieldInfo field = fields[x];
				DeserializeField(obj, field, serializer, null);
			}
			return obj;
		}

		private static void DeserializeField(object obj, FieldInfo field, IObjectSerializer serializer, IArraySerializer arraySerializer)
		{
			Type fieldType = field.FieldType;
			TypeSerializer typeSerializer = GetTypeSerializer(fieldType);
			if(typeSerializer != null)
			{
				field.SetValue(obj, typeSerializer.Deserialize(field, serializer, arraySerializer));
			}
		}
	}
}
