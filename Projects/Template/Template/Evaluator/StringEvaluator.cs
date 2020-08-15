namespace ProceduralLevel.Common.Template.Evaluator
{
	public class StringEvaluator: AEvaluator
	{
		public override EEvaluatorType EvalType { get { return EEvaluatorType.String; } }

		private readonly string m_Text;

		public StringEvaluator(string text)
		{
			m_Text = text;
		}

		public override object Evaluate(TemplateManager manager, object data)
		{
			return m_Text;
		}

		public override string ToString()
		{
			return m_Text;
		}
	}
}
