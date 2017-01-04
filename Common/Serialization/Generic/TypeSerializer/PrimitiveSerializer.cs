using System;
using System.Reflection;

namespace ProceduralLevel.Common.Serialization.Serializers
{
	public class PrimitiveSerializer: TypeSerializer
	{
		public override object Deserialize(FieldInfo fieldInfo, IObjectSerializer serializer, IArraySerializer arraySerializer)
		{
			if(serializer != null)
			{
				return serializer.TryRead(fieldInfo.Name);
			}
			else
			{
				return arraySerializer.Read();
			}
		}

		public override void Serialize(object value, FieldInfo fieldInfo, IObjectSerializer serializer, IArraySerializer arraySerializer)
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
