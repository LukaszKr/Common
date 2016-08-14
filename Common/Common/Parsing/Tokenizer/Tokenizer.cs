using System.Collections.Generic;

namespace Common.Parsing
{
	public class Tokenizer
    {
		private List<string> m_Separators = new List<string>();
		private List<Token> m_Tokens;

		private bool m_AutoTrim;
		private string m_LastString = null;

		public Tokenizer(bool autoTrim = true)
		{
			m_Tokens = new List<Token>();
			m_AutoTrim = autoTrim;
		}

		public void AddSeparator(string separator)
		{
			m_Separators.Add(separator);
		}

		public void AddSeparator(char separator)
		{
			m_Separators.Add(separator.ToString());
		}

		public void AddSeparators(params string[] separators)
		{
			for(int x = 0; x < separators.Length; x++)
			{
				m_Separators.Add(separators[x]);
			}
		}

		public void AddSeparators(params char[] separators)
		{
			for(int x = 0; x < separators.Length; x++)
			{
				m_Separators.Add(separators[x].ToString());
			}
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
				text = str;
			}
			for(int index = 0; index < text.Length; index++)
			{
				for(int sepIndex = 0; sepIndex < m_Separators.Count; sepIndex++)
				{
					string separator = m_Separators[sepIndex];
					if(text.Substring(index, separator.Length) == separator)
					{
						string value = text.Substring(current, index-current);
						if(m_AutoTrim)
						{
							value = value.Trim();
						}
						PushToken(new Token(value, false));
						PushToken(new Token(separator, true));
						index += separator.Length;
						current = index;
						index--;
						break;
					}
				}
				m_LastString = str.Substring(current);
			}
		}

		public List<Token> Flush()
		{
			List<Token> tokens = m_Tokens;
			PushToken(new Token(m_LastString, false));
			m_Tokens = new List<Token>();
			return tokens;
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
    }
}