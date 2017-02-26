using System;
using System.Reflection;

namespace ProceduralLevel.Common.Serialization
{
	public abstract class TypeSerializer
    {
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
		public abstract void Serialize(object value, FieldInfo fieldInfo, IObjectSerializer serializer, IArraySerializer arraySerializer);
		public abstract object Deserialize(Type fieldType, string fieldName, IObjectSerializer serializer, IArraySerializer arraySerializer);

		protected static IObjectSerializer GetObjectSerializer(string fieldName, IObjectSerializer obj, IArraySerializer arr)
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

		protected static IArraySerializer GetArraySerializer(string fieldName, IObjectSerializer obj, IArraySerializer arr)
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

		protected static IObjectSerializer GetObjectDeserializer(string fieldName, IObjectSerializer obj, IArraySerializer arr)
		{
			if(obj != null)
			{
				return obj.TryReadObject(fieldName);
			}
			else
			{
				return arr.ReadObject();
			}
		}

		protected static IArraySerializer GetArrayDeserializer(string fieldName, IObjectSerializer obj, IArraySerializer arr)
		{
			if(obj != null)
			{
				return obj.TryReadArray(fieldName);
			}
			else
			{
				return arr.ReadArray();
			}
		}
	}
}
