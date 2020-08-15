using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ProceduralLevel.Common.Template.Evaluator
{
	public class MethodEvaluator: AEvaluator
	{
		public override EEvaluatorType EvalType { get { return EEvaluatorType.Method; } }

		public readonly AEvaluator Name;
		private readonly List<AEvaluator> m_Args = new List<AEvaluator>();

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
			Type type = data.GetType();

			string methodName = Name.ToString();
			MethodInfo method = type.GetMethod(methodName);

			int argCount = m_Args.Count;
			object[] args = new object[argCount];
			for(int x = 0; x < argCount; ++x)
			{
				args[x] = m_Args[x].Evaluate(manager, data);
			}

			return method.Invoke(data, args);
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
