using System;

namespace ProceduralLevel.Common.Serialization
{
	[AttributeUsage(AttributeTargets.Field)]
	public class IgnorePropertyAttribute: Attribute
    {
    }

	[AttributeUsage(AttributeTargets.Field)]
	public class SerializablePropertyAttribute: Attribute
	{

	}
}
