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

		public override object Evaluate(object data)
		{
			object context = Key.Evaluate(data);
			if(context == null)
			{
				throw new Exception(string.Format("{0} is null in context: {1}", Key.ToString(), (context != null? context.ToString(): "NULL")));
			}
			object result = Value.Evaluate((Dot? context: data));
			if(Dot)
			{
				return result;
			}
			else
			{
				return GetValue(result.ToString(), context);
			}
		}

		public override string ToString()
		{
			return string.Format("{0}[{1}]", Key.ToString(), Value.ToString());
		}
	}
}
