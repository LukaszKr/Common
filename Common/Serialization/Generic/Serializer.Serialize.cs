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
				SerializeField(obj, field, serializer, null);
			}
		}


		private static void SerializeField(object obj, FieldInfo field, IObjectSerializer serializer, IArraySerializer arraySerializer)
		{
			object value = field.GetValue(obj);
			if(value == null)
			{
				return;
			}
			Type fieldType = field.FieldType;

			if(fieldType.IsArray)
			{
				Array array = value as Array;
				IArraySerializer subArray = GetArraySerializer(field, serializer, arraySerializer);
				int arrayLength = array.Length;
				for(int y = 0; y < arrayLength; y++)
				{
					arraySerializer.Write(array.GetValue(y));
				}
			}
			else if(fieldType.IsClass && fieldType != typeof(string))
			{
				IObjectSerializer subOject = GetObjectSerializer(field, serializer, arraySerializer);
				Serialize(obj, subOject);
			}
			else
			{
				if(serializer != null)
				{
					serializer.Write(field.Name, value);
				}
				else
				{
					arraySerializer.Write(value);
				}
			}
		}

		private static IObjectSerializer GetObjectSerializer(FieldInfo field, IObjectSerializer obj, IArraySerializer arr)
		{
			if(obj != null)
			{
				return obj.WriteObject(field.Name);
			}
			else
			{
				return arr.WriteObject();
			}
		}

		private static IArraySerializer GetArraySerializer(FieldInfo field, IObjectSerializer obj, IArraySerializer arr)
		{
			if(obj != null)
			{
				return obj.WriteArray(field.Name);
			}
			else
			{
				return arr.WriteArray();
			}
		}
	}
}
