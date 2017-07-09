namespace ProceduralLevel.Template.Evaluator
{
	public class StringEvaluator: AEvaluator
	{
		public override EEvaluatorType EvalType { get { return EEvaluatorType.String; } }

		private string m_Text;

		public StringEvaluator(string text)
		{
			m_Text = text;
		}

		public override object Evaluate(Manager manager, object data)
		{
			return m_Text;
		}

		public override string ToString()
		{
			return m_Text;
		}
	}
}
