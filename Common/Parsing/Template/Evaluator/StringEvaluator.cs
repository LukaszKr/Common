namespace ProceduralLevel.Common.Parsing.Template
{
	public class StringEvaluator: AEvaluator
	{
		public readonly string Str;

		public StringEvaluator(string str) : base(EEvaluatorType.String)
		{
			Str = str;
		}

		public override object Evaluate(Manager manager, object data)
		{
			return Str;
		}

		public override string ToString()
		{
			return Str;
		}
	}
}
