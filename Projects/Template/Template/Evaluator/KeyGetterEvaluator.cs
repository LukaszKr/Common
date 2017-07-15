﻿namespace ProceduralLevel.Template.Evaluator
{
	public class KeyGetterEvaluator: AEvaluator
	{
		public override EEvaluatorType EvalType { get { return EEvaluatorType.KeyGetter; } }

		private AEvaluator m_Key;
		private AEvaluator m_Value;
		private bool m_Dot;

		public KeyGetterEvaluator(AEvaluator key, AEvaluator value, bool dot)
		{
			m_Key = key;
			m_Value = value;
			m_Dot = dot;
		}

		public override object Evaluate(Manager manager, object data)
		{
			object context = m_Key.Evaluate(manager, data);
			object value = m_Value.Evaluate(manager, (m_Dot? context: data));

			if(m_Dot)
			{
				return value;
			}
			else
			{
				return Get(context, value.ToString());
			}
		}

		public override string ToString()
		{
			return string.Format("{0}[{1}]", m_Key.ToString(), m_Value.ToString());
		}
	}
}