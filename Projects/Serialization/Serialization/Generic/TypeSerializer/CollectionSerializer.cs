using System;
using System.Collections;
using System.Reflection;

namespace ProceduralLevel.Serialization
{
	class CollectionSerializer: TypeSerializer
	{
		public override bool SerializesClass { get { return true; } }

		public override object Deserialize(ASerializer processor, Type fieldType, string fieldName, AObject serializer, AArray arraySerializer)
		{
			AArray subArray = GetArrayDeserializer(fieldName, serializer, arraySerializer);
			if(subArray == null)
			{
				return null;
			}
			
			object collection = Activator.CreateInstance(fieldType);
			MethodInfo add;
			Type elementType;
#if NET_CORE
			TypeInfo info = fieldType.GetTypeInfo();
			add = info.GetMethod("Add");
			elementType = info.GetGenericArguments()[0];
#else
			add = fieldType.GetMethod("Add");
			elementType = fieldType.GetGenericArguments()[0];
#endif
			int length = subArray.Count;
			object[] invokeParams = new object[1];
			
			TypeSerializer typeSerializer = ASerializer.GetTypeSerializer(elementType);


			for(int x = 0; x < length; x++)
			{
				invokeParams[0] = typeSerializer.Deserialize(processor, elementType, fieldName, null, subArray);
				add.Invoke(collection, invokeParams);
			}
			return collection;
		}

		public override void Serialize(ASerializer processor, object value, FieldInfo fieldInfo, AObject serializer, AArray arraySerializer)
		{
			AArray subArray = GetArraySerializer(fieldInfo.Name, serializer, arraySerializer);

			Type elementType;
#if NET_CORE
			elementType = value.GetType().GetTypeInfo().GetGenericArguments()[0];
#else
			elementType = value.GetType().GetGenericArguments()[0];
#endif
			TypeSerializer typeSerializer = ASerializer.GetTypeSerializer(elementType);

			ICollection collection = value as ICollection;
			foreach(object obj in collection)
			{
				typeSerializer.Serialize(processor, obj, fieldInfo, null, subArray);
			}
		}

		protected override bool CheckType(Type fieldType, bool isClass)
		{
#if NET_CORE
			return typeof(ICollection).GetTypeInfo().IsAssignableFrom(fieldType);
#else
			return typeof(ICollection).IsAssignableFrom(fieldType);
#endif
		}
	}
}
