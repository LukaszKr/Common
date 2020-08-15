namespace ProceduralLevel.Common.Template.Evaluator
{
	public class ArrayGetterEvaluator: AEvaluator
	{
		public override EEvaluatorType EvalType { get { return EEvaluatorType.ArrayGetter; } }

		private readonly AEvaluator m_Key;
		private readonly AEvaluator m_Value;

		public ArrayGetterEvaluator(AEvaluator key, AEvaluator value)
		{
			m_Key = key;
			m_Value = value;
		}

		public override object Evaluate(object context, object globalContext)
		{
			object key = m_Key.Evaluate(context, globalContext);
			object value = m_Value.Evaluate(context, globalContext);

			return Get(key, value.ToString());
		}

		public override string ToString()
		{
			return string.Format("{0}[{1}]", m_Key.ToString(), m_Value.ToString());
		}
	}
}
