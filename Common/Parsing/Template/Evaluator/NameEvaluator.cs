namespace ProceduralLevel.Common.Parsing.Template
{
	public class NameEvaluator: AEvaluator
	{
		public readonly string Name;

		public NameEvaluator(string name) : base(EEvaluatorType.Name)
		{
			Name = name;
		}

		public override object Evaluate(Manager manager, object data)
		{
			return Name;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
