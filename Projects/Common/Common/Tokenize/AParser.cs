using System.Collections.Generic;

namespace ProceduralLevel.Common.Tokenize
{
	public abstract class AParser<TokenizerType, DataType>
		where TokenizerType: ATokenizer
	{
		private List<Token> m_Tokens;
		private int m_Next = 0;

		#if DEBUG
		protected string m_ConsumedSoFar = "";
		#endif

		protected TokenizerType m_Tokenizer;

		public AParser(TokenizerType tokenizer)
		{
			m_Tokenizer = tokenizer;
		}

		protected Token ConsumeToken()
		{
			Token token = m_Tokens[m_Next++];
			#if DEBUG
			m_ConsumedSoFar += token.Value;
			#endif
			return token;
		}

		protected Token PeekToken()
		{
			return m_Tokens[m_Next];
		}

		protected bool HasTokens()
		{
			return (m_Next < m_Tokens.Count);
		}

		protected void SkipToNextNonEmpty()
		{
			Token token = null;
			while(true)
			{
				token = PeekToken();
				if(token.IsSeparator || !string.IsNullOrEmpty(token.Value.Trim()))
				{
					return;
				}
				ConsumeToken();
			}
		}

		public AParser<TokenizerType, DataType> Parse(string str)
		{
			m_Tokenizer.Tokenize(str);
			m_Next = 0;
			return this;
		}

		public AParser<TokenizerType, DataType> ParseLine(string str)
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
			#if DEBUG
			m_ConsumedSoFar = "";
			#endif
		}
	}
}
