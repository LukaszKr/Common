namespace ProceduralLevel.Common.Template.Evaluator
{
	public class TemplateNameEvaluator: AEvaluator
	{
		public override EEvaluatorType EvalType { get { return EEvaluatorType.Name; } }

		public readonly string Name;

		public TemplateNameEvaluator(string name)
		{
			Name = name;
		}

		public override object Evaluate(object context, object globalContext)
		{
			return Name;
		}

		public override string ToString()
		{
			return TemplateConst.TEMPLATE_NAME+Name;
		}
	}
}
