using System;
using System.Collections.Generic;

namespace ProceduralLevel.Common.Parsing.Template
{
	public class Manager
    {
		private Parser m_Parser;

		private Dictionary<string, Template> m_Templates = new Dictionary<string, Template>();
		private Dictionary<string, Delegate> m_Methods = new Dictionary<string, Delegate>();

		public Manager()
		{
			m_Parser = new Parser();
			AddMethod<string, object>("compile", Compile);
		}

		private string Compile(string templateName, object data)
		{
			if(data != null && templateName != null)
			{
				Template template = GetTemplate(templateName);
				if(template != null)
				{
					return template.Compile(this, data);
				}
				else
				{
					return string.Format("TEMPLATE_MISSING({0})", templateName);
				}
			}
			return "";
		}

		public void ClearTemplates()
		{
			m_Templates.Clear();
		}

		public Template[] Parse(string str)
		{
			m_Parser.Parse(str);
			Template[] templates = m_Parser.Flush();
			Add(templates);
			return templates;
		}

		public void Add(params Template[] templates)
		{
			for(int x = 0; x < templates.Length; x++)
			{
				Template template = templates[x];
				m_Templates[template.Name] = template;
				OnAdd(template);
			};
		}

		protected virtual void OnAdd(Template template) { }

		public Template GetTemplate(string name)
		{
			m_Templates.TryGetValue(name, out var template);
			return template;
		}

		public void AddMethod<T1>(string name, Func<T1, string> method)
		{
			m_Methods[name] = method;
		}

		public void AddMethod<T1, T2>(string name, Func<T1, T2, string> method)
		{
			m_Methods[name] = method;
		}

		public void AddMethod<T1, T2, T3>(string name, Func<T1, T2, T3, string> method)
		{
			m_Methods[name] = method;
		}

		public void AddMethod(string name, Delegate method)
		{
			m_Methods[name] = method;
		}

		public Delegate GetMethod(string name)
		{
			m_Methods.TryGetValue(name, out var method);
			return method;
		}
	}
}
