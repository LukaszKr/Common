using System;
using System.Reflection;

namespace ProceduralLevel.Common.Serialization
{
	public static class ObjectSerializer
    {
		public static void Serialize<DataType>(DataType obj, IObjectSerializer serializer) where DataType: class
		{
			Type type = obj.GetType();
			FieldInfo[] fields = type.GetFields(BindingFlags.Public);
			for(int x = 0; x < fields.Length; x++)
			{
				FieldInfo field = fields[x];
				Type fieldType = field.GetType();
				if(fieldType.IsArray)
				{
					//IArraySerializer array = serializer.WriteArray(field.Name);
					//Type elementType = fieldType.GetElementType();

				}
				else if(fieldType.IsClass)
				{
					Serialize(field.GetValue(obj), serializer.WriteObject(field.Name));
				}
				else
				{
					serializer.WriteObject(field.Name, field.GetValue(obj));
				}
			}
		}
    }
}
