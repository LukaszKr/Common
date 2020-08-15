using ProceduralLevel.Common.Tokenize;

namespace ProceduralLevel.Common.Template.Parser
{
	public class TemplateTokenizer: ATokenizer
	{
		private static readonly char[] m_Default = new char[]
		{
			TemplateConst.BRACES_OPEN
		};

		private static readonly char[] m_Template = new char[]
		{
			TemplateConst.BRACES_OPEN, TemplateConst.BRACES_CLOSE,
			TemplateConst.PARENT_OPEN, TemplateConst.PARENT_CLOSE,
			TemplateConst.SQUARE_OPEN, TemplateConst.SQUARE_CLOSE,
			TemplateConst.SEPARATOR, TemplateConst.QUOTE,
			TemplateConst.DOT, TemplateConst.TEMPLATE_NAME
		};

		public TemplateTokenizer(bool autoTrim = false) : base(autoTrim)
		{
		}

		protected override char[] GetSeparators(Token token)
		{
			switch(token.Value[0])
			{
				case TemplateConst.BRACES_CLOSE:
					return m_Default;
				default:
					return m_Template;
			}
		}

		protected override char[] GetSeparators()
		{
			return m_Default;
		}
	}
}
