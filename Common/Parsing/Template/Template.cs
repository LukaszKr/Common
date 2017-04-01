using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

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

		public string Compile(Manager manager, object data)
		{
			if(data == null)
			{
				return "";
			}

			if(data.GetType().IsArray)
			{
				Array arr = (Array)data;
				StringBuilder compiled = new StringBuilder(arr.Length);
				for(int x = 0; x < arr.Length; x++)
				{
					compiled.Append(CompileObject(manager, arr.GetValue(x)));
				}
				return compiled.ToString();
			}
			else
			{
				IEnumerable enumerable = data as IEnumerable;
				if(enumerable != null)
				{
					StringBuilder compiled = new StringBuilder();
					foreach(object obj in enumerable)
					{
						compiled.Append(CompileObject(manager, obj));
					}
					return compiled.ToString();
				}
				else
				{
					return CompileObject(manager, data);
				}
			}
		}

		private string CompileObject(Manager manager, object data)
		{
			string compiled = "";
			for(int x = 0; x <  m_Evaluators.Count; x++)
			{
				AEvaluator evaluator = m_Evaluators[x];
				compiled += evaluator.Evaluate(manager, data).ToString();
			}
			return compiled.Trim();
		}
    }
}
