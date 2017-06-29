using System;
using System.Reflection;

namespace ProceduralLevel.Serialization
{
	public class ArraySerializer: TypeSerializer
	{
		public override bool SerializesClass { get {  return true; } }

		public override object Deserialize(ASerializer processor, Type fieldType, string fieldName, AObject serializer, AArray arraySerializer)
		{
			AArray subArray = GetArrayDeserializer(fieldName, serializer, arraySerializer);
			if(subArray == null)
			{
				return null;
			}

			int length = subArray.Count;
			Type elementType = fieldType.GetElementType();
			TypeSerializer typeSerializer = ASerializer.GetTypeSerializer(elementType);

			Array array = Array.CreateInstance(elementType, length);
			for(int x = 0; x < length; x++)
			{
				array.SetValue(typeSerializer.Deserialize(processor, elementType, fieldName, null, subArray), x);
			}
			return array;
		}

		public override void Serialize(ASerializer processor, object value, FieldInfo fieldInfo, AObject serializer, AArray arraySerializer)
		{
			Array array = value as Array;
			AArray subArray = GetArraySerializer(fieldInfo.Name, serializer, arraySerializer);
			Type elementType = fieldInfo.FieldType.GetElementType();
			TypeSerializer typeSerializer = ASerializer.GetTypeSerializer(elementType);

			int arrayLength = array.Length;
			for(int y = 0; y < arrayLength; y++)
			{
				typeSerializer.Serialize(processor, array.GetValue(y), fieldInfo, null, subArray);
			}
		}

		protected override bool CheckType(Type fieldType, bool isClass)
		{
			return (fieldType.IsArray);
		}
	}
}
