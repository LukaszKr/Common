namespace ProceduralLevel.Common.Template.Evaluator
{
	public class NameEvaluator: AEvaluator
	{
		public override EEvaluatorType EvalType { get { return EEvaluatorType.Name; } }

		public readonly string Name;

		public NameEvaluator(string name)
		{
			Name = name;
		}

		public override object Evaluate(TemplateManager manager, object data)
		{
			return Name;
		}

		public override string ToString()
		{
			return TemplateConst.SPECIAL+Name;
		}
	}
}
