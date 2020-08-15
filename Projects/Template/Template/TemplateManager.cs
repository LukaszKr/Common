using ProceduralLevel.Common.Template.Parser;
using System.Collections.Generic;

namespace ProceduralLevel.Common.Template
{
	public class TemplateManager
	{
		private readonly TemplateParser m_Parser = new TemplateParser();
		private readonly Dictionary<string, TextTemplate> m_Templates = new Dictionary<string, TextTemplate>();

		public TemplateManager()
		{

		}

		public List<TextTemplate> Parse(string rawTemplate)
		{
			List<TextTemplate> templates = m_Parser.Parse(rawTemplate).Flush();
			for(int x = 0; x < templates.Count; x++)
			{
				AddTemplate(templates[x]);
			}
			return templates;
		}

		public void AddTemplate(TextTemplate template)
		{
			m_Templates.Add(template.Name, template);
		}

		public bool RemoveTemplate(string name)
		{
			return m_Templates.Remove(name);
		}

		public TextTemplate GetTemplate(string name)
		{
			return m_Templates[name];
		}
	}
}
