using System;
using System.Reflection;

namespace ProceduralLevel.Serialization
{
	public abstract class TypeSerializer
    {
		public abstract bool SerializesClass { get; }

		public bool CheckType(Type fieldType)
		{
			bool isClass;
#if NET_CORE
			isClass = fieldType.GetTypeInfo().IsClass;
#else
			isClass = fieldType.IsClass;
#endif
			return CheckType(fieldType, isClass);
		}

		protected abstract bool CheckType(Type fieldType, bool isClass);
		public abstract void Serialize(ASerializer processor, object value, FieldInfo fieldInfo, AObject serializer, AArray arraySerializer);
		public abstract object Deserialize(ASerializer processor, Type fieldType, string fieldName, AObject serializer, AArray arraySerializer);

		protected static AObject GetObjectSerializer(string fieldName, AObject obj, AArray arr)
		{
			if(obj != null)
			{
				return obj.WriteObject(fieldName);
			}
			else
			{
				return arr.WriteObject();
			}
		}

		protected static AArray GetArraySerializer(string fieldName, AObject obj, AArray arr)
		{
			if(obj != null)
			{
				return obj.WriteArray(fieldName);
			}
			else
			{
				return arr.WriteArray();
			}
		}

		protected static AObject GetObjectDeserializer(string fieldName, AObject obj, AArray arr)
		{
			if(obj != null)
			{
				return obj.ReadObject(fieldName);
			}
			else
			{
				return arr.ReadObject();
			}
		}

		protected static AArray GetArrayDeserializer(string fieldName, AObject obj, AArray arr)
		{
			if(obj != null)
			{
				return obj.ReadArray(fieldName);
			}
			else
			{
				return arr.ReadArray();
			}
		}
	}
}
