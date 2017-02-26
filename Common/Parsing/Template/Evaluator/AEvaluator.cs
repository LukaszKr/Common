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
				bool isArray;
#if NET_CORE
				isArray = data.GetType().GetTypeInfo().IsArray;
#else
				isArray = data.GetType().IsArray;
#endif
				if(!isArray)
				{
					FieldInfo field;
#if NET_CORE
						field = data.GetType().GetTypeInfo().GetField(key);
#else
					field = data.GetType().GetField(key);
#endif
					if(field != null)
					{
						return field.GetValue(data);
					}
					else
					{
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
