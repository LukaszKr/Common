using System.Collections.Generic;
using System.Text;

namespace ProceduralLevel.Common.Tokenize
{
	public abstract class ATokenizer
    {
		public const char ESCAPE_CHAR = '\\';
		public const char NEW_LINE = '\n';

		private char[] m_ActiveSeparators = null;
		private List<Token> m_Tokens;

		private bool m_AutoTrim;
		private bool m_Escaped;

		private int m_Cursor;
		private int m_Line;
		private int m_Column;

		private StringBuilder m_RawBuffer;
		private StringBuilder m_ValueBuffer;

		protected virtual char EscapeChar { get { return ESCAPE_CHAR; } }

		public ATokenizer(bool autoTrim = false)
		{
			m_Tokens = new List<Token>();
			m_AutoTrim = autoTrim;
			m_RawBuffer = new StringBuilder();
			m_ValueBuffer = new StringBuilder();
			Clear();
		}

		protected virtual void Clear()
		{
			m_Tokens = new List<Token>();
			m_RawBuffer.Length = 0;
			m_ValueBuffer.Length = 0;
			m_Cursor = 0;
			m_Line = 0;
			m_Column = 0;
			m_Escaped = false;
		}

		public List<Token> Flush()
		{
			List<Token> tokens = m_Tokens;
			string remaining = m_ValueBuffer.ToString()+ReadFromBuffer(m_RawBuffer.Length);
			if(remaining.Length > 0)
			{
				m_Tokens.Add(new Token(remaining, ETokenType.Value, m_Line, m_Column));
			}
			Clear();
			return tokens;
		}

		public List<Token> Peek()
		{
			return m_Tokens;
		}

		protected abstract char[] GetSeparators();

		protected virtual char[] GetSeparators(Token separator)
		{
			return GetSeparators();
		}

		public ATokenizer Tokenize(string str)
		{
			if(m_RawBuffer.Length == 0)
			{
				m_ActiveSeparators = GetSeparators();
			}
			else
			{
				m_RawBuffer.Remove(0, m_Cursor);
				m_Cursor = 0;
			}
			m_RawBuffer.Append(str);

			for(int index = 0; index < m_RawBuffer.Length; index++)
			{
				char chr = m_RawBuffer[index];

				if(m_Escaped)
				{
					m_ValueBuffer.Append(chr);
					m_Escaped = false;
					continue;
				}
				if(chr == ESCAPE_CHAR)
				{
					m_ValueBuffer.Append(ReadFromBuffer(index));
					m_Cursor = index+2;
					m_Escaped = true;
					continue;
				}
				else if(chr == NEW_LINE)
				{
					m_Column = 0;
					m_Line ++;
				}

				if(IsSeparator(chr))
				{
					m_ValueBuffer.Append(ReadFromBuffer(index));
					if(m_ValueBuffer.Length > 0)
					{
						string value = m_ValueBuffer.ToString();
						m_ValueBuffer.Length = 0;
						if(m_AutoTrim)
						{
							value = value.Trim();
						}
						if(value.Length > 0)
						{
							m_Tokens.Add(new Token(value, ETokenType.Value, m_Line, m_Column));
						}
						m_Column += value.Length;
					}
					Token separator = new Token(chr.ToString(), ETokenType.Separator, m_Line, m_Column);
					m_Tokens.Add(separator);
					m_Column ++;
					m_ActiveSeparators = GetSeparators(separator);

					m_Cursor = index+1;
				}
			}

			return this;
		}

		private bool IsSeparator(char chr)
		{
			for(int x = 0; x < m_ActiveSeparators.Length; x++)
			{
				if(m_ActiveSeparators[x] == chr)
				{
					return true;
				}
			}
			return false;
		}

		private string ReadFromBuffer(int index)
		{
			int length = index-m_Cursor;
			if(length > 0)
			{
				return m_RawBuffer.ToString(m_Cursor, length);
			}
			return string.Empty;
		}
	}
}