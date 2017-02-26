using System;
using System.Collections.Generic;
using System.Reflection;
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

		public void AddEvaluator(AEvaluator evaluator)
		{
			m_Args.Add(evaluator);
		}

		public override object Evaluate(Manager manager, object data)
		{
			object result = Name.Evaluate(manager, data);
			Delegate func = result as Delegate;
			MethodInfo method =  result as MethodInfo;
			if(func == null && method == null)
			{
				return string.Format("METHOD_MISSING({0})", Name.ToString());
			}
			object[] args = new object[m_Args.Count];
			for(int x = 0; x < args.Length; x++)
			{
				args[x] = m_Args[x].Evaluate(manager, data);
			}
			if(func != null)
			{
				return func.DynamicInvoke(args);
			}
			else
			{
				return method.Invoke(data, args);
			}
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
