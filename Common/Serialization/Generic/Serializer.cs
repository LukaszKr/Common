using System;
using System.Collections.Generic;
using System.Reflection;

namespace ProceduralLevel.Common.Serialization
{
	public static partial class Serializer
    {
		private static FieldInfo[] GetSerializableFields(Type type)
		{
			return type.GetFields(BindingFlags.Public | BindingFlags.Instance);
		}
	}
}
