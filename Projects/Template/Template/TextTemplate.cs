using ProceduralLevel.Common.Template.Evaluator;
using System.Collections.Generic;
using System.Text;

namespace ProceduralLevel.Common.Template
{
	public class TextTemplate
	{
		public readonly string Name;

		private readonly List<AEvaluator> m_Evaluators = new List<AEvaluator>();

		public TextTemplate(string name)
		{
			Name = name;
		}

		public void AddEvalautor(params AEvaluator[] evaluators)
		{
			m_Evaluators.AddRange(evaluators);
		}

		public string Compile(TemplateManager manager, object data)
		{
			StringBuilder sb = new StringBuilder();
			Compile(manager, data, sb);
			return sb.ToString();
		}

		public void Compile(TemplateManager manager, object data, StringBuilder sb)
		{
			if(data.GetType().IsArray)
			{
				object[] arr = data as object[];
				for(int x = 0; x < arr.Length; x++)
				{
					CompileObject(manager, arr[x], sb);
				}
			}
			else
			{
				CompileObject(manager, data, sb);
			}
		}

		private void CompileObject(TemplateManager manager, object data, StringBuilder sb)
		{
			for(int x = 0; x < m_Evaluators.Count; x++)
			{
				AEvaluator evaluator = m_Evaluators[x];
				object result = evaluator.Evaluate(manager, data);
				if(result != null)
				{
					sb.Append(result.ToString());
				}
			}
		}
	}
}
