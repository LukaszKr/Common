namespace ProceduralLevel.Common.Template.Evaluator
{
	public class GetterEvaluator: AEvaluator
	{
		public override EEvaluatorType EvalType { get { return EEvaluatorType.Getter; } }

		private readonly string m_ParamName;

		public GetterEvaluator(string paramName)
		{
			m_ParamName = paramName;
		}

		public override object Evaluate(TemplateManager manager, object data)
		{
			if(m_ParamName == "this")
			{
				return data;
			}
			else
			{
				return Get(data, m_ParamName);
			}
		}

		public override string ToString()
		{
			return m_ParamName;
		}
	}
}
