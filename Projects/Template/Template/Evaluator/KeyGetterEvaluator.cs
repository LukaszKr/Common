﻿namespace ProceduralLevel.Common.Template.Evaluator
{
	internal class KeyGetterEvaluator: AEvaluator
	{
		public override EEvaluatorType EvalType { get { return EEvaluatorType.KeyGetter; } }

		private readonly AEvaluator m_Key;
		private readonly AEvaluator m_Value;

		public KeyGetterEvaluator(AEvaluator key, AEvaluator value)
		{
			m_Key = key;
			m_Value = value;
		}

		public override object Evaluate(object context, object globalContext)
		{
			object key = m_Key.Evaluate(context, globalContext);
			object value = m_Value.Evaluate(key, globalContext);

			return value;
		}

		public override string ToString()
		{
			return string.Format("{0}.{1}", m_Key.ToString(), m_Value.ToString());
		}
	}
}
