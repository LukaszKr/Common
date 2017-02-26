namespace ProceduralLevel.Common.Parsing.Template
{
	public class TemplateTokenizer: Tokenizer
	{
		private static string[] m_Script = new string[]
		{
			Consts.BRACKET_OPEN, Consts.BRACKET_CLOSE,
			Consts.SQUARE_OPEN, Consts.SQUARE_CLOSE,
			Consts.PARENT_OPEN, Consts.PARENT_CLOSE,
			Consts.PARAM_SEPARATOR, Consts.DOT,
			Consts.QUOTE, Consts.ESCAPED_QUOTE, Consts.SINGLE_QUOTE,
			Consts.TEMPLATE_MARKER
		};

		private static string[] m_Default = new string[]
		{
			Consts.BRACKET_OPEN
		};

		protected override string[] GetDefaultSeparators()
		{
			return m_Default;
		}

		protected override string[] GetSeparators(Token token)
		{
			switch(token.Value)
			{
				case Consts.BRACKET_CLOSE:
					return m_Default;
				default:
					return m_Script;
			}
		}
	}
}
