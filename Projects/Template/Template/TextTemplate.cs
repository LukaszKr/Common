using System;
using System.Collections.Generic;
using System.Text;
using ProceduralLevel.Common.Template.Evaluator;

namespace ProceduralLevel.Common.Template
{
	public class TextTemplate
	{
		private readonly List<AEvaluator> m_Evaluators = new List<AEvaluator>();

		internal TextTemplate()
		{
		}

		internal void AddEvalautor(params AEvaluator[] evaluators)
		{
			m_Evaluators.AddRange(evaluators);
		}

		public string Compile(object context)
		{
			StringBuilder sb = new StringBuilder();
			Compile(sb, context);
			return sb.ToString();
		}

		public void Compile(StringBuilder sb, object context)
		{
			if(context.GetType().IsArray)
			{
				Array arr = (Array)context;
				int length = arr.Length;
				for(int x = 0; x < length; x++)
				{
					CompileObject(sb, arr.GetValue(x));
				}
			}
			else
			{
				CompileObject(sb, context);
			}
		}

		private void CompileObject(StringBuilder sb, object context)
		{
			int count = m_Evaluators.Count;
			for(int x = 0; x < count; x++)
			{
				AEvaluator evaluator = m_Evaluators[x];
				object result = evaluator.Evaluate(context);
				if(result != null)
				{
					sb.Append(result.ToString());
				}
			}
		}
	}
}
