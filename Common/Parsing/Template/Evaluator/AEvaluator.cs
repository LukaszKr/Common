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

		public abstract object Evaluate(object data);


		protected object GetValue(string key, object data)
		{
			Dictionary<string, object> dict = data as Dictionary<string, object>;
			if(dict != null)
			{
				object tmp;
				dict.TryGetValue(key, out tmp);
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
				}
				else
				{
					Array arr = (Array)data;
					return arr.GetValue(Convert.ToInt32(key));
				}
			}
			return "";
		}
    }
}
