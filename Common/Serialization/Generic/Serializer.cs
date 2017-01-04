using ProceduralLevel.Common.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ProceduralLevel.Common.Serialization
{
	public static partial class Serializer
    {
		public static List<TypeSerializer> Serializers = new List<TypeSerializer>();

		static Serializer()
		{
			Serializers.Add(new ArraySerializer());
			Serializers.Add(new PrimitiveSerializer());
			Serializers.Add(new ClassSerializer());
		}

		private static FieldInfo[] GetSerializableFields(Type type)
		{
#if NET_CORE
			return type.GetTypeInfo().GetFields(BindingFlags.Public | BindingFlags.Instance);
#else
			return type.GetFields(BindingFlags.Public | BindingFlags.Instance);
#endif
		}
	}
}
