using System;
using System.Reflection;

namespace ProceduralLevel.Common.Serialization
{
	public static partial class Serializer
    {

		public static void Serialize(object obj, IObjectSerializer serializer)
		{
			if(obj == null)
			{
				return;
			}

			FieldInfo[] fields = GetSerializableFields(obj.GetType());
			int length = fields.Length;

			for(int x = 0; x < length; x++)
			{
				FieldInfo field = fields[x];
				SerializeField(field.GetValue(obj), field, serializer, null);
			}
		}


		private static void SerializeField(object value, FieldInfo field, IObjectSerializer serializer, IArraySerializer arraySerializer)
		{
			if(value == null)
			{
				return;
			}
			Type fieldType = field.FieldType;
			TypeSerializer typeSerializer = GetTypeSerializer(fieldType);
			if(typeSerializer != null)
			{
				typeSerializer.Serialize(value, field, serializer, arraySerializer);
			}
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
	}
}
