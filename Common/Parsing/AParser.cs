using System;
using System.Collections.Generic;
using System.Text;

namespace ProceduralLevel.Common.Parsing
{
    public abstract class AParser<DataType>
    {
		private List<Token> m_Tokens;
		private int m_Next = 0;

		protected Tokenizer m_Tokenizer;

		public AParser(Tokenizer tokenizer)
		{
			m_Tokenizer = tokenizer;
		}

		protected Token ConsumeToken()
		{
			return m_Tokens[m_Next++];
		}

		protected Token PeekToken()
		{
			return m_Tokens[m_Next];
		}

		protected bool HasTokens()
		{
			return (m_Next < m_Tokens.Count);
		}

		public DataType Parse(string str)
		{
			m_Tokenizer.Tokenize(str);
			m_Next = 0;
			m_Tokens = m_Tokenizer.Flush();
			return Parse();
		}

		protected abstract DataType Parse();
    }
}
