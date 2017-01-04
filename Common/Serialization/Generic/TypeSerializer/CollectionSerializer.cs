using System;
using System.Collections;
using System.Reflection;

namespace ProceduralLevel.Common.Serialization
{
	class CollectionSerializer: TypeSerializer
	{
		public override object Deserialize(Type fieldType, string fieldName, IObjectSerializer serializer, IArraySerializer arraySerializer)
		{
			IArraySerializer subArray = GetArrayDeserializer(fieldName, serializer, arraySerializer);
			if(subArray == null)
			{
				return null;
			}
			
			object collection = Activator.CreateInstance(fieldType);
			MethodInfo add = fieldType.GetMethod("Add");
			int length = subArray.Count;
			object[] invokeParams = new object[1];
			Type elementType = fieldType.GetGenericArguments()[0];
			TypeSerializer typeSerializer = Serializer.GetTypeSerializer(elementType);


			for(int x = 0; x < length; x++)
			{
				invokeParams[0] = typeSerializer.Deserialize(elementType, fieldName, null, subArray);
				add.Invoke(collection, invokeParams);
			}
			return collection;
		}

		public override void Serialize(object value, FieldInfo fieldInfo, IObjectSerializer serializer, IArraySerializer arraySerializer)
		{
			IArraySerializer subArray = GetArraySerializer(fieldInfo.Name, serializer, arraySerializer);

			Type elementType = value.GetType().GetGenericArguments()[0];
			TypeSerializer typeSerializer = Serializer.GetTypeSerializer(elementType);

			ICollection collection = value as ICollection;
			foreach(object obj in collection)
			{
				typeSerializer.Serialize(obj, fieldInfo, null, subArray);
			}
		}

		protected override bool CheckType(Type fieldType, bool isClass)
		{
			return typeof(ICollection).IsAssignableFrom(fieldType);
		}
	}
}
