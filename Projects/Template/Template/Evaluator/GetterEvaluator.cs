namespace ProceduralLevel.Common.Template.Evaluator
{
	internal class GetterEvaluator: AEvaluator
	{
		public override EEvaluatorType EvalType { get { return EEvaluatorType.Getter; } }

		private readonly string m_ParamName;

		public GetterEvaluator(string paramName)
		{
			m_ParamName = paramName.Trim();
		}

		public override object Evaluate(object context)
		{
			if(m_ParamName == "this")
			{
				return context;
			}
			else
			{
				return Get(context, m_ParamName);
			}
		}

		public override string ToString()
		{
			return m_ParamName;
		}
	}
}
