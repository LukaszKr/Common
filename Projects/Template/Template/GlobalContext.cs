namespace ProceduralLevel.Common.Template
{
	public class GlobalContext
	{
		protected readonly TemplateManager m_Templates;

		public GlobalContext(TemplateManager templates)
		{
			m_Templates = templates;
		}

		public string Include(string templateName, object context)
		{
			TextTemplate template = m_Templates.GetTemplate(templateName);
			return template.Compile(context, this);
		}
	}
}
