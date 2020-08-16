namespace ProceduralLevel.Common.Template.Evaluator
{
	internal class DotGetterEvaluator
		: AEvaluator
	{
		public override EEvaluatorType EvalType { get { return EEvaluatorType.DotGetter; } }

		private readonly AEvaluator m_Key;
		private readonly AEvaluator m_Value;

		public DotGetterEvaluator(AEvaluator key, AEvaluator value)
		{
			m_Key = key;
			m_Value = value;
		}

		public override object Evaluate(object context)
		{
			object key = m_Key.Evaluate(context);
			object value = m_Value.Evaluate(key);

			return value;
		}

		public override string ToString()
		{
			return string.Format("{0}.{1}", m_Key.ToString(), m_Value.ToString());
		}
	}
}
