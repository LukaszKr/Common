namespace ProceduralLevel.Common.Template.Evaluator
{
	public class KeyGetterEvaluator: AEvaluator
	{
		public override EEvaluatorType EvalType { get { return EEvaluatorType.KeyGetter; } }

		private readonly AEvaluator m_Key;
		private readonly AEvaluator m_Value;

		public KeyGetterEvaluator(AEvaluator key, AEvaluator value)
		{
			m_Key = key;
			m_Value = value;
		}

		public override object Evaluate(TemplateManager manager, object data)
		{
			object context = m_Key.Evaluate(manager, data);
			object value = m_Value.Evaluate(manager, context);

			return value;
		}

		public override string ToString()
		{
			return string.Format("{0}.{1}", m_Key.ToString(), m_Value.ToString());
		}
	}
}
