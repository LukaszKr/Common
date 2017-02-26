using System;
using System.Collections.Generic;
using System.Reflection;

namespace ProceduralLevel.Common.Parsing.Template
{
	public class GetterEvaluator: AEvaluator
	{
		public readonly string Param;

		public GetterEvaluator(string param) : base(EEvaluatorType.Getter)
		{
			Param = param;
		}

		public override object Evaluate(object data)
		{
			object result;
			if(Param != null && Param.Length > 0)
			{
				if(Param == "this")
				{
					result = data;
				}
				else
				{
					result = GetValue(Param, data);
				}
			}
			else
			{
				result = data;
			}
			if(result != null)
			{
				return result;
			}
			else
			{
				return string.Format("({0}: NULL)", Param);
			}
		}

		public override string ToString()
		{
			return Param;
		}
	}
}
