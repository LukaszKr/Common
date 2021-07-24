using System;
using ProceduralLevel.Common.Tokenize;

namespace ProceduralLevel.Common.Serialization.CSV
{
	public sealed class CSVTokenizer : ATokenizer
	{
		public const char ALT_SEPARATOR = ';';
		public const char SEPARATOR = ',';
		public const char QUOTE = '"';
		public const char TERMINATOR = '\n';

		private static char[] m_AllSeparators = new char[] { SEPARATOR, ALT_SEPARATOR, QUOTE, TERMINATOR };
		private static char[] m_DefaultSeparators = new char[] { SEPARATOR, QUOTE, TERMINATOR };
		private static char[] m_AltSeparators = new char[] { ALT_SEPARATOR, QUOTE, TERMINATOR };

		private static char[] m_QuoteSeparators = new char[] { QUOTE };

		private bool m_QuoteOpen = false;
		private char[] m_ExpectedSeparators = null;
		public char LastDetectedSeparator { get; private set; }

		protected override void Clear()
		{
			base.Clear();
			m_ExpectedSeparators = null;
		}

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
					return m_AllSeparators;
				case SEPARATOR:
					if(m_ExpectedSeparators == null)
					{
						m_ExpectedSeparators = m_DefaultSeparators;
						LastDetectedSeparator = SEPARATOR;
					}
					return m_ExpectedSeparators;
				case ALT_SEPARATOR:
					if(m_ExpectedSeparators == null)
					{
						m_ExpectedSeparators = m_AltSeparators;
						LastDetectedSeparator = ALT_SEPARATOR;
					}
					return m_ExpectedSeparators;
				default:
					throw new NotImplementedException();
			}
		}
	}
}
