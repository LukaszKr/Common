using ProceduralLevel.Common.Tokenize;
using System;

namespace ProceduralLevel.Common.Serialization.CSV
{
	public sealed class CSVTokenizer: ATokenizer
	{
		public const char ALT_SEPARATOR = ';';
		public const char SEPARATOR = ',';
		public const char QUOTE = '"';
		public const char TERMINATOR = '\n';

		private static char[] m_AllSeparators = new char[] { SEPARATOR, ALT_SEPARATOR, QUOTE, TERMINATOR };
		private static char[] m_QuoteSeparators = new char[] { QUOTE };

		private bool m_QuoteOpen = false;

		protected override char[] GetSeparators()
		{
			return m_AllSeparators;
		}

		protected override char[] GetSeparators(Token separator)
		{
			switch(separator.Value[0])
			{
				case QUOTE:
					m_QuoteOpen = !m_QuoteOpen;
					if(!m_QuoteOpen)
					{
						return m_AllSeparators;
					}
					return m_QuoteSeparators;
				case TERMINATOR:
				case SEPARATOR:
				case ALT_SEPARATOR:
					return m_AllSeparators;
				default:
					throw new NotImplementedException();
			}
		}
	}
}
