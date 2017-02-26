using System.Collections.Generic;
using System.Text;

namespace ProceduralLevel.Common.Parsing.Template
{
	public class FunctionEvaluator: AEvaluator
    {
		public readonly AEvaluator Name;
		private List<AEvaluator> m_Args = new List<AEvaluator>();

		public FunctionEvaluator(AEvaluator name, params AEvaluator[] args): base(EEvaluatorType.Function)
		{
			Name = name;
			for(int x = 0; x < args.Length; x++)
			{
				m_Args.Add(args[x]);
			}
		}

		public void addEvaluator(AEvaluator evaluator)
		{
			m_Args.Add(evaluator);
		}

		public override object Evaluate(object data)
		{
			return ""; //TODO
		}

		public override string ToString()
		{
			StringBuilder builder = new StringBuilder(3+m_Args.Count*2);
			builder.Append(Name.ToString()).Append("(");
			for(int x = 0; x < m_Args.Count; x++)
			{
				AEvaluator arg = m_Args[x];
				builder.Append(arg.ToString());
				if(x < m_Args.Count-1)
				{
					builder.Append(", ");
				}
			}
			builder.Append(")");
			return builder.ToString();
		}
	}
}
