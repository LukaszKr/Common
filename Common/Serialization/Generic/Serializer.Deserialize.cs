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

		private static object Deserialize(Type type, IObjectSerializer serializer)
		{
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
			if(fieldType.IsArray)
			{
				IArraySerializer subArray = GetArrayDeserializer(field, serializer, arraySerializer);
				if(subArray == null)
				{
					return;
				}
				int length = subArray.Count;
				Type elementType = fieldType.GetElementType();
				Array array = Array.CreateInstance(elementType, length);
				for(int x = 0; x < length; x++)
				{
					//array.SetValue(, x);
				}
				field.SetValue(obj, array);
			}
			else
			{
				field.SetValue(obj, FetchData(fieldType, field.Name, serializer, null));
			}
		}

		private static object FetchData(Type fieldType, string fieldName, IObjectSerializer serializer, IArraySerializer arraySerializer)
		{
			if(arraySerializer != null)
			{
				return null;
			}
			else if(fieldType.IsClass && fieldType != typeof(string))
			{
				return Deserialize(fieldType, serializer.TryReadObject(fieldName));
			}
			else
			{
				return serializer.TryRead(fieldName);
			}
		}

		private static IObjectSerializer GetObjectDeserializer(FieldInfo field, IObjectSerializer obj, IArraySerializer arr)
		{
			if(obj != null)
			{
				return obj.TryReadObject(field.Name);
			}
			else
			{
				return arr.ReadObject();
			}
		}

		private static IArraySerializer GetArrayDeserializer(FieldInfo field, IObjectSerializer obj, IArraySerializer arr)
		{
			if(obj != null)
			{
				return obj.TryReadArray(field.Name);
			}
			else
			{
				return arr.ReadArray();
			}
		}
	}
}
