using System;
using System.Collections;
using System.Reflection;

namespace ProceduralLevel.Common.Serialization.Serializers
{
	public class ClassSerializer: TypeSerializer
	{
		public override object Deserialize(FieldInfo fieldInfo, IObjectSerializer serializer, IArraySerializer arraySerializer)
		{
			if(serializer != null)
			{
				return Serializer.Deserialize(fieldInfo.FieldType, serializer.TryReadObject(fieldInfo.Name));
			}
			else
			{
				return Serializer.Deserialize(fieldInfo.FieldType.GetElementType(), arraySerializer.ReadObject());
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
