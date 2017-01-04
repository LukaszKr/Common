using System;
using System.Collections;
using System.Reflection;

namespace ProceduralLevel.Common.Serialization.Serializers
{
	public class ClassSerializer: TypeSerializer
	{
		public override object Deserialize(Type fieldType, string fieldName, IObjectSerializer serializer, IArraySerializer arraySerializer)
		{
			if(serializer != null)
			{
				return Serializer.Deserialize(fieldType, serializer.TryReadObject(fieldName));
			}
			else
			{
				return Serializer.Deserialize(fieldType, arraySerializer.ReadObject());
			}
		}

		public override void Serialize(object value, FieldInfo fieldInfo, IObjectSerializer serializer, IArraySerializer arraySerializer)
		{
			IObjectSerializer subSerializer = GetObjectSerializer(fieldInfo.Name, serializer, arraySerializer);
			Serializer.Serialize(value, subSerializer);
		}

		protected override bool CheckType(Type fieldType, bool isClass)
		{
			return (isClass && fieldType != typeof(IEnumerable));
		}
	}
}
