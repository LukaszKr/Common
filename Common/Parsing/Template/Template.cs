using System;
using System.Collections.Generic;

namespace ProceduralLevel.Common.Parsing.Template
{
	public class Template
    {
		public readonly string Name;

		private List<AEvaluator> m_Evaluators = new List<AEvaluator>();

		public Template(string name)
		{
			Name = name;
		}

		public void Add(AEvaluator evaluator)
		{
			m_Evaluators.Add(evaluator);
		}

		public string Compile(object data)
		{
			if(data == null)
			{
				return "";
			}

			if(data.GetType().IsArray)
			{
				string compiled = "";
				Array arr = (Array)data;
				for(int x = 0; x < arr.Length; x++)
				{
					compiled += CompileObject(arr.GetValue(x));
				}
				return compiled;
			}
			else
			{
				return CompileObject(data);
			}
		}

		private string CompileObject(object data)
		{
			string compiled = "";
			for(int x = 0; x <  m_Evaluators.Count; x++)
			{
				AEvaluator evaluator = m_Evaluators[x];
				compiled += evaluator.Evaluate(data).ToString();
			}
			return compiled.Trim();
		}
    }
}
