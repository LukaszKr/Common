﻿using System;
using System.Collections.Generic;

namespace ProceduralLevel.Common.Parsing
{
	public abstract class Tokenizer
    {
		private string[] m_Separators = null;
		private List<Token> m_Tokens;

		private bool m_AutoTrim;
		private string m_LastString = null;

		public Tokenizer(bool autoTrim = false)
		{
			m_Tokens = new List<Token>();
			m_AutoTrim = autoTrim;
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
				m_Separators = GetDefaultSeparators();
				text = str;
			}
			for(int index = 0; index < text.Length; index++)
			{
				for(int sepIndex = 0; sepIndex < m_Separators.Length; sepIndex++)
				{
					string separator = m_Separators[sepIndex];
					if(index+separator.Length <= text.Length && text.Substring(index, separator.Length) == separator)
					{
						string value = text.Substring(current, index-current);
						if(m_AutoTrim)
						{
							value = value.Trim();
						}
						PushToken(new Token(value, ETokenType.Value));
						Token separatorToken = new Token(separator, ETokenType.Separator);
						PushToken(separatorToken);
						m_Separators = GetSeparators(separatorToken);
						index += separator.Length;
						current = index;
						index--;
						break;
					}
				}
			}

			m_LastString = text.Substring(current);
		}

		public List<Token> Flush()
		{
			List<Token> tokens = m_Tokens;
			PushToken(new Token(m_LastString, ETokenType.Value));
			m_Tokens = new List<Token>();
			m_LastString = null;
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
	}
}