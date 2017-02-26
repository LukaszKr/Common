using System.Collections.Generic;

namespace ProceduralLevel.Common.Parsing.Template
{
	public class Manager
    {
		private Parser m_Parser;

		private Dictionary<string, Template> m_Templates = new Dictionary<string, Template>();
    
		public Manager()
		{
			m_Parser = new Parser();
		}

		public void Parse(string str)
		{
			m_Parser.Parse(str);
			Add(m_Parser.Flush());
		}

		public void Add(params Template[] templates)
		{
			for(int x = 0; x < templates.Length; x++)
			{
				Template template = templates[x];
				m_Templates[template.Name] = template;
			};
		}

		public Template GetTemplate(string name)
		{
			Template template;
			m_Templates.TryGetValue(name, out template);
			return template;
		}
	}
}
