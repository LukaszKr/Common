﻿using System;
using System.Reflection;

namespace ProceduralLevel.Common.Serialization.Serializers
{
	public class ArraySerializer: TypeSerializer
	{
		public override object Deserialize(Type fieldType, string fieldName, IObjectSerializer serializer, IArraySerializer arraySerializer)
		{
			IArraySerializer subArray = GetArrayDeserializer(fieldName, serializer, arraySerializer);
			if(subArray == null)
			{
				return null;
			}

			int length = subArray.Count;
			Type elementType = fieldType.GetElementType();
			TypeSerializer typeSerializer = Serializer.GetTypeSerializer(elementType);

			Array array = Array.CreateInstance(elementType, length);
			for(int x = 0; x < length; x++)
			{
				array.SetValue(typeSerializer.Deserialize(elementType, fieldName, null, subArray), x);
			}
			return array;
		}

		public override void Serialize(object value, FieldInfo fieldInfo, IObjectSerializer serializer, IArraySerializer arraySerializer)
		{
			Array array = value as Array;
			IArraySerializer subArray = GetArraySerializer(fieldInfo.Name, serializer, arraySerializer);
			Type elementType = fieldInfo.FieldType.GetElementType();
			TypeSerializer typeSerializer = Serializer.GetTypeSerializer(elementType);

			int arrayLength = array.Length;
			for(int y = 0; y < arrayLength; y++)
			{
				typeSerializer.Serialize(array.GetValue(y), fieldInfo, null, subArray);
			}
		}

		protected override bool CheckType(Type fieldType, bool isClass)
		{
			return (fieldType.IsArray);
		}
	}
}
