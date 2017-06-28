using System;
using System.Collections.Generic;

namespace ProceduralLevel.Common.Parsing
{
	public abstract class ATokenizer
    {
		private string[] m_ActiveSeparators = null;
		private List<Token> m_Tokens;

		private bool m_AutoTrim;
		private string m_LastString = null;
		private int m_CursorPosition = 0;
		private bool m_Escaped;
		private string m_EscapeSeparator;

		public ATokenizer(bool autoTrim = false, string escapeSeparator = null)
		{
			m_Tokens = new List<Token>();
			m_AutoTrim = autoTrim;
			m_EscapeSeparator = escapeSeparator;
		}

		protected abstract string[] GetDefaultSeparators();
		protected virtual string[] GetSeparators(Token token)
		{
			return GetDefaultSeparators();
		}

		public void Tokenize(string str)
		{
			string text;
			int current = 0;
			if(m_LastString != null)
			{
				text = m_LastString+str;
			}
			else
			{
				m_ActiveSeparators = GetDefaultSeparators();
				text = str;
			}

			int oldPosition = m_CursorPosition;
			int valueOffset = 0;
			m_LastString = string.Empty;


			for(int index = 0; index < text.Length; index++)
			{
				if(m_Escaped)
				{
					m_Escaped = false;
					continue;
				}
				for(int sepIndex = 0; sepIndex < m_ActiveSeparators.Length; sepIndex++)
				{
					string separator = m_ActiveSeparators[sepIndex];
					if(CompareToSeparator(text, separator, index))
					{
						m_Escaped = IsEscapeSeparator(text, index);
						int leng = index-current;
						if(leng != 0)
						{
							m_LastString += text.Substring(current, leng);
							current += leng-1+(m_Escaped? separator.Length: 0);
						}
						if(m_Escaped)
						{
							index += separator.Length-1;
							current += separator.Length;
							break;
						}

						if(m_AutoTrim)
						{
							m_LastString = m_LastString.Trim();
						}
						PushToken(new Token(m_LastString, ETokenType.Value, valueOffset));

						Token separatorToken = new Token(separator, ETokenType.Separator, oldPosition + index);
						PushToken(separatorToken);
						m_ActiveSeparators = GetSeparators(separatorToken);

						index += separator.Length;
						current = index;
						valueOffset = index;
						m_CursorPosition = oldPosition + index;
						index--;
						m_LastString = string.Empty;
						break;
					}
				}
			}

			m_LastString += text.Substring(current);
		}

		private bool CompareToSeparator(string text, string separator, int index)
		{
			int textLen = text.Length;
			int sepLen = separator.Length;

			if(index+sepLen > textLen)
			{
				return false;
			}

			for(int x = 0; x < sepLen; x++)
			{
				if(text[x+index] != separator[x])
				{
					return false;
				}
			}
			return true;

		}

		public List<Token> Flush()
		{
			List<Token> tokens = m_Tokens;
			PushToken(new Token(m_LastString, ETokenType.Value, m_CursorPosition));
			Reset();
			return tokens;
		}

		protected virtual void Reset()
		{
			m_Tokens = new List<Token>();
			m_LastString = null;
			m_CursorPosition = 0;
			m_Escaped = false;
		}

		public List<Token> Peek()
		{
			return m_Tokens;
		}

		private void PushToken(Token token, bool ignoreEmpty = true)
		{
			if(!ignoreEmpty || !string.IsNullOrEmpty(token.Value))
			{
				m_Tokens.Add(token);
			}
		}

		private bool StartsWith(string str, string with, int offset)
		{
			int length = offset+Math.Min(str.Length-offset, with.Length);
			if(length < with.Length)
			{
				return false;
			}
			for(int x = 0; x < length; x++)
			{
				if(str[x+offset] != with[x])
				{
					return false;
				}
			}
			return true;
		}

		protected bool IsEscapeSeparator(string value, int index)
		{
			return m_EscapeSeparator != null && CompareToSeparator(value, m_EscapeSeparator, index);
		}
	}
}