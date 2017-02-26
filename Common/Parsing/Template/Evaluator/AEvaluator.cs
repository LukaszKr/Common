using System;
using System.Collections.Generic;
using System.Reflection;

namespace ProceduralLevel.Common.Parsing.Template
{
	public abstract class AEvaluator
    {
		public readonly EEvaluatorType Type;

		public AEvaluator(EEvaluatorType type)
		{
			Type = type;
		}

		public abstract object Evaluate(Manager mananger, object data);


		protected object GetValue(Manager manager, string key, object data)
		{
			if(data is Dictionary<string, object> dict)
			{
				dict.TryGetValue(key, out object tmp);
				return tmp;
			}
			else
			{
				Type type = data.GetType();
				bool isArray;
#if NET_CORE
				isArray = type.GetTypeInfo().IsArray;
#else
				isArray = type.IsArray;
#endif
				if(!isArray)
				{
					FieldInfo field;
#if NET_CORE
						field = type.GetTypeInfo().GetField(key);
#else
					field = type.GetField(key);
#endif
					if(field != null)
					{
						return field.GetValue(data);
					}
					else
					{
						MethodInfo[] methods;
#if NET_CORE
						methods = type.GetTypeInfo().GetMethods();
#else
						methods = type.GetMethods();
#endif
						MethodInfo method = null;
						for(int x = 0; x < methods.Length; x++)
						{
							MethodInfo maybe = methods[x];
							if(maybe.Name == key)
							{
								method = maybe;
								break;
							}
						}

						if(method != null)
						{
							#if NET_CORE
							return method;
#else
							return method;
#endif
						}
						return manager.GetMethod(key);
					}
				}
				else
				{
					Array arr = (Array)data;
					return arr.GetValue(Convert.ToInt32(key));
				}
			}
		}
    }
}
