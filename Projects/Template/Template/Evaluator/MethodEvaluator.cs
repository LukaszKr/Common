using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ProceduralLevel.Common.Template.Evaluator
{
	public class MethodEvaluator: AEvaluator
	{
		public override EEvaluatorType EvalType { get { return EEvaluatorType.Method; } }

		private readonly string m_MethodName;
		private readonly bool m_GlobalContext;
		private readonly List<AEvaluator> m_Args = new List<AEvaluator>();

		public MethodEvaluator(string methodName, bool globalContext, params AEvaluator[] args)
		{
			m_MethodName = methodName;
			m_GlobalContext = globalContext;
			m_Args.AddRange(args);
		}

		public void AddArgument(AEvaluator evaluator)
		{
			m_Args.Add(evaluator);
		}

		public override object Evaluate(object context, object globalContext)
		{
			object usedContext = (m_GlobalContext? globalContext: context);
			Type type = usedContext.GetType();

			m_MethodName.ToString();
			MethodInfo method = type.GetMethod(m_MethodName);

			int argCount = m_Args.Count;
			object[] args = new object[argCount];
			for(int x = 0; x < argCount; ++x)
			{
				args[x] = m_Args[x].Evaluate(context, globalContext);
			}

			return method.Invoke(usedContext, args);
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(m_MethodName).Append(TemplateConst.PARENT_OPEN);
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
