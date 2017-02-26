﻿using System.Collections.Generic;

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

		public string Compile(object data, Dictionary<string, object> scope = null)
		{
			if(data == null)
			{
				return "";
			}

			if(scope == null)
			{
				scope = new Dictionary<string, object>();
			}

			if(data.GetType().IsArray)
			{
				string compiled = "";
				object[] arr = (object[])data;
				for(int x = 0; x < arr.Length; x++)
				{
					compiled += CompileObject(arr[x], scope);
				}
				return compiled;
			}
			else
			{
				return CompileObject(data, scope);
			}
		}

		private string CompileObject(object data, Dictionary<string, object> scope)
		{
			string compiled = "";
			for(int x = 0; x <  m_Evaluators.Count; x++)
			{
				AEvaluator evaluator = m_Evaluators[x];
				compiled += evaluator.Evaluate(data, scope).ToString();
			}
			return compiled.Trim();
		}
    }
}
