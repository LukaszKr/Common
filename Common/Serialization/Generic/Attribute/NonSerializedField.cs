using System;

namespace ProceduralLevel.Common.Serialization
{
	[AttributeUsage(AttributeTargets.Field)]
	public class NonSerializedFieldAttribute: Attribute
	{
	}
}
