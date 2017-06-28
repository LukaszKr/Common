using System;

namespace ProceduralLevel.Serialization
{
	[AttributeUsage(AttributeTargets.Field)]
	public class NonSerializedFieldAttribute: Attribute
	{
	}
}
