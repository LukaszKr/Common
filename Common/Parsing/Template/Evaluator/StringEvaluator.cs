using System.Collections.Generic;

namespace ProceduralLevel.Common.Parsing.Template
{
	public class StringEvaluator: AEvaluator
	{
		public readonly string Str;

		public StringEvaluator(string str) : base(EEvaluatorType.String)
		{
			Str = str;
		}

		public override object Evaluate(object data, Dictionary<string, object> scope)
		{
			return Str;
		}

		public override string ToString()
		{
			return Str;
		}
	}
}
