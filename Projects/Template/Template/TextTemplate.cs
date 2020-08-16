using ProceduralLevel.Common.Template.Evaluator;
using System.Collections.Generic;
using System.Text;

namespace ProceduralLevel.Common.Template
{
	public class TextTemplate
	{
		public readonly string Name;

		private readonly TemplateManager m_Manager;
		private readonly List<AEvaluator> m_Evaluators = new List<AEvaluator>();

		internal TextTemplate(string name, TemplateManager manager)
		{
			Name = name;
			m_Manager = manager;
			m_Manager.AddTemplate(this);
		}

		internal void AddEvalautor(params AEvaluator[] evaluators)
		{
			m_Evaluators.AddRange(evaluators);
		}

		public string Compile(object context, object globalContext)
		{
			StringBuilder sb = new StringBuilder();
			Compile(sb, context, globalContext);
			return sb.ToString();
		}

		public void Compile(StringBuilder sb, object context, object globalContext)
		{
			if(context.GetType().IsArray)
			{
				object[] arr = context as object[];
				for(int x = 0; x < arr.Length; x++)
				{
					CompileObject(sb, arr[x], globalContext);
				}
			}
			else
			{
				CompileObject(sb, context, globalContext);
			}
		}

		private void CompileObject(StringBuilder sb, object context, object globalContext)
		{
			for(int x = 0; x < m_Evaluators.Count; x++)
			{
				AEvaluator evaluator = m_Evaluators[x];
				object result = evaluator.Evaluate(context, globalContext);
				if(result != null)
				{
					sb.Append(result.ToString());
				}
			}
		}
	}
}
