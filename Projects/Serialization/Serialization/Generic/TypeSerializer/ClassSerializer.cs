using System;
using System.Collections;
using System.Reflection;

namespace ProceduralLevel.Common.Serialization.Serializers
{
	public class ClassSerializer: TypeSerializer
	{
		public override bool SerializesClass { get { return true; } }

		public override object Deserialize(ASerializer processor, Type fieldType, string fieldName, IObjectSerializer serializer, IArraySerializer arraySerializer)
		{
			if(serializer != null)
			{
				return processor.DeserializeObject(fieldType, serializer.TryReadObject(fieldName));
			}
			else
			{
				return processor.DeserializeObject(fieldType, arraySerializer.ReadObject());
			}
		}

		public override void Serialize(ASerializer processor, object value, FieldInfo fieldInfo, IObjectSerializer serializer, IArraySerializer arraySerializer)
		{
			IObjectSerializer subSerializer = GetObjectSerializer(fieldInfo.Name, serializer, arraySerializer);
			processor.SerializeObject(value, subSerializer);
		}

		protected override bool CheckType(Type fieldType, bool isClass)
		{
			return (isClass && fieldType != typeof(IEnumerable));
		}
	}
}
