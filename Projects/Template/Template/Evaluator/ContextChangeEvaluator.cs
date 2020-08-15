namespace ProceduralLevel.Common.Template.Evaluator
{
	public class ContextEvaluator: AEvaluator
	{
		public override EEvaluatorType EvalType { get { return EEvaluatorType.Context; } }

		public override object Evaluate(TemplateManager manager, object data)
		{
			throw new System.NotImplementedException();
		}
	}
}
