using System;
using System.Collections.Generic;
using System.Reflection;

namespace ProceduralLevel.ECS
{
	public static class ComponentArrayHelper
	{
		public static FieldInfo[] FindArrayFields(Type type)
		{
			List<FieldInfo> fields = new List<FieldInfo>();
			FindArrayFields(fields, type, BindingFlags.Instance | BindingFlags.Public);
			Type currentType = type;
			while(currentType != null)
			{
				FindArrayFields(fields, currentType, BindingFlags.Instance | BindingFlags.NonPublic);
				currentType = currentType.BaseType;
			}

			return fields.ToArray();
		}

		private static void FindArrayFields(List<FieldInfo> fieldsList, Type type, BindingFlags binding)
		{
			Type arrayType = typeof(IComponentArray);

			FieldInfo[] fields = type.GetFields(binding);
			for(int x = 0; x < fields.Length; ++x)
			{
				FieldInfo field = fields[x];
				Type fieldType = field.FieldType;
				if(arrayType.IsAssignableFrom(fieldType))
				{
					fieldsList.Add(field);
				}
			}
		}

		public static void MapArrays(IComponentArray[] arrays, object target)
		{
			Type targetType = target.GetType();
			FieldInfo[] targetFields = FindArrayFields(targetType);

			for(int x = 0; x < targetFields.Length; ++x)
			{
				FieldInfo field = targetFields[x];
				Type fieldType = field.FieldType;
				IComponentArray matchingArray = null;
				for(int y = 0; y < arrays.Length; ++y)
				{
					IComponentArray array = arrays[y];
					if(array.GetType() == fieldType)
					{
						matchingArray = array;
						break;
					}
				}
				if(matchingArray != null)
				{
					field.SetValue(target, matchingArray);
				}
				else
				{
					throw new KeyNotFoundException(string.Format("[{0} requires {1}]", targetType.Name, fieldType.GetGenericArguments()[0].Name));
				}
			}
		}

		public static IComponentArray[] FindComponentArrays(object source)
		{
			Type sourceType = source.GetType();
			FieldInfo[] fields = FindArrayFields(sourceType);
			IComponentArray[] components = new IComponentArray[fields.Length];

			for(int x = 0; x < fields.Length; ++x)
			{
				FieldInfo field = fields[x];
				IComponentArray array = field.GetValue(source) as IComponentArray;
				if(array == null)
				{
					throw new ArgumentNullException(string.Format("[{0} in {1}]", field.Name, sourceType.Name));
				}
				components[x] = array;
			}

			return components;
		}
	}
}
