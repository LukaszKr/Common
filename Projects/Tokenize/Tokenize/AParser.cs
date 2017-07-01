﻿using System.Collections.Generic;

namespace ProceduralLevel.Tokenize
{
	public abstract class AParser<DataType>
    {
		private List<Token> m_Tokens;
		private int m_Next = 0;

		protected ATokenizer m_Tokenizer;

		public AParser(ATokenizer tokenizer)
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

		public AParser<DataType> Parse(string str)
		{
			m_Tokenizer.Tokenize(str);
			m_Next = 0;
			return this;
		}

		public AParser<DataType> ParseLine(string str)
		{
			m_Tokenizer.Tokenize(str+ATokenizer.NEW_LINE);
			m_Next = 0;
			return this;
		}

		public DataType Flush()
		{
			m_Tokens = m_Tokenizer.Flush();
			DataType parsed = Parse();
			Reset();
			return parsed;
		}

		protected abstract DataType Parse();

		protected virtual void Reset()
		{
			m_Next = 0;
			m_Tokens = null;
		}
    }
}
