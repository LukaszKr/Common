using System;
using System.Collections.Generic;
using System.Reflection;

namespace ProceduralLevel.Common.Parsing.Template
{
	public class KeyGetterEvaluator: AEvaluator
	{
		public readonly AEvaluator Key;
		public readonly AEvaluator Value;
		public readonly bool Dot;

		public KeyGetterEvaluator(AEvaluator key, AEvaluator value, bool dot) : base(EEvaluatorType.KeyGetter)
		{
			Key = key;
			Value = value;
			Dot = dot;
		}

		public override object Evaluate(object data, Dictionary<string, object> scope)
		{
			object context = Key.Evaluate(data, scope);
			if(context == null)
			{
				throw new Exception(string.Format("{0} is null in context: {1}", Key.ToString(), (context != null? context.ToString(): "NULL")));
			}
			object result = Value.Evaluate((Dot? context: data), scope);
			if(Dot)
			{
				return result;
			}
			else
			{
				Dictionary<string, object> dict = context as Dictionary<string, object>;
				if(dict != null)
				{
					object tmp;
					dict.TryGetValue(result.ToString(), out tmp);
					return tmp;
				}
				else
				{
					FieldInfo field;
#if NET_CORE
						field = context.GetType().GetTypeInfo().GetField(result.ToString());
#else
					field = context.GetType().GetField(result.ToString());
#endif
					if(field != null)
					{
						return field.GetValue(context);
					}
				}
				return "";
			}
		}

		public override string ToString()
		{
			return string.Format("{0}[{1}]", Key.ToString(), Value.ToString());
		}
	}
}
