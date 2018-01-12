using System.Collections.Generic;
using System.Text;

namespace ProceduralLevel.Common.Template.Evaluator
{
	public class MethodEvaluator: AEvaluator
	{
		public override EEvaluatorType EvalType { get { return EEvaluatorType.Method; } }

		public readonly AEvaluator Name;
		private List<AEvaluator> m_Args = new List<AEvaluator>();

		public MethodEvaluator(AEvaluator name, params AEvaluator[] args)
		{
			Name = name;
			m_Args.AddRange(args);
		}

		public void AddArgument(AEvaluator evaluator)
		{
			m_Args.Add(evaluator);
		}

		public override object Evaluate(TemplateManager manager, object data)
		{
			return "NOT_IMPLEMENTED";
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(Name.ToString()).Append(TemplateConst.PARENT_OPEN);
			for(int x = 0; x < m_Args.Count; x++)
			{
				if(x > 0)
				{
					sb.Append(TemplateConst.SEPARATOR).Append(' ');
				}

				AEvaluator arg = m_Args[x];
				sb.Append(arg.ToString());
			}
			sb.Append(TemplateConst.PARENT_CLOSE);
			return sb.ToString();
		}
	}
}
