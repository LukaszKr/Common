﻿using ProceduralLevel.Common.Helper;
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
			Serializers.Add(new PrimitiveSerializer());
			Serializers.Add(new ArraySerializer());
			Serializers.Add(new CollectionSerializer());
			Serializers.Add(new ClassSerializer());
		}

		private static FieldInfo[] GetSerializableFields(Type type)
		{
			FieldInfo[] fields;
			FieldInfo[] privateFields;
#if NET_CORE
			fields = type.GetTypeInfo().GetFields(BindingFlags.Public | BindingFlags.Instance);
			privateFields = type.GetTypeInfo().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
#else
			fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
			privateFields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
#endif
			int count = 0;
			int privateCount = 0;
			for(int x = 0; x < fields.Length; x++)
			{
				FieldInfo field = fields[x];
				if(!HasAttribute<NonSerializedFieldAttribute>(field))
				{
					count ++;
				}
				else
				{
					fields[x] = null;
				}
			}
			for(int x = 0; x < privateFields.Length; x++)
			{
				FieldInfo field = privateFields[x];

				if(HasAttribute<SerializedFieldAttribute>(field))
				{
					privateCount++;
				}
				else
				{
					privateFields[x] = null;
				}
			}
			if(count+privateCount > 0)
			{
				int index = fields.Length;
				FieldInfo[] result = fields.Resize(count+privateCount);
				for(int x = 0; x < fields.Length; x++)
				{
					FieldInfo field = fields[x];
					if(field != null)
					{
						result[index] = field;
						index ++;
					}
				}
				for(int x = 0; x < privateFields.Length; x++)
				{
					FieldInfo field = privateFields[x];
					if(field != null)
					{
						result[index] = field;
						index ++;
					}
				}
				return result;
			}
			return null;
		}

		private static bool HasAttribute<Type>(FieldInfo field) where Type: Attribute
		{
#if NET_CORE
				return (field.GetCustomAttribute<Type>() != null);
#else
			return (field.GetCustomAttributes(typeof(Type), true).Length > 0);
#endif
		}
	}
}
