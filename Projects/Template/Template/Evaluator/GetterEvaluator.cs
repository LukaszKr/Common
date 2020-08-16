namespace ProceduralLevel.Common.Template.Evaluator
{
	internal class GetterEvaluator: AEvaluator
	{
		public override EEvaluatorType EvalType { get { return EEvaluatorType.Getter; } }

		private readonly string m_ParamName;
		private readonly bool m_GlobalContext;

		public GetterEvaluator(string paramName, bool globalContext)
		{
			m_ParamName = paramName.Trim();
			m_GlobalContext = globalContext;
		}

		public override object Evaluate(object context, object globalContext)
		{
			if(m_ParamName == "this")
			{
				return (m_GlobalContext ? globalContext : context);
			}
			else
			{
				if(m_GlobalContext)
				{
					return Get(globalContext, m_ParamName);
				}
				return Get(context, m_ParamName);
			}
		}

		public override string ToString()
		{
			return m_ParamName;
		}
	}
}
