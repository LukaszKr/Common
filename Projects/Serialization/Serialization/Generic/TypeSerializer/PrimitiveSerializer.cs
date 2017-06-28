using System;
using System.Reflection;

namespace ProceduralLevel.Serialization
{
	public class PrimitiveSerializer: TypeSerializer
	{
		public override bool SerializesClass { get { return false; } }

		public override object Deserialize(ASerializer processor, Type fieldType, string fieldName, IObjectSerializer serializer, IArraySerializer arraySerializer)
		{
			if(serializer != null)
			{
				return serializer.TryRead(fieldName);
			}
			else
			{
				return arraySerializer.Read();
			}
		}

		public override void Serialize(ASerializer processor, object value, FieldInfo fieldInfo, IObjectSerializer serializer, IArraySerializer arraySerializer)
		{
			if(serializer != null)
			{
				serializer.Write(fieldInfo.Name, value);
			}
			else
			{
				arraySerializer.Write(value);
			}
		}

		protected override bool CheckType(Type fieldType, bool isClass)
		{
			return (!isClass || fieldType == typeof(string));
		}
	}
}
