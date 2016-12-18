using System;
using System.Collections.Generic;
using System.Globalization;

namespace ProceduralLevel.Common.Parsing
{
	public class JsonParser
    {
		private Tokenizer m_Tokenizer;

		public JsonParser()
		{
			m_Tokenizer = new JSONTokenizer();
		}

		public JsonObject Parse(string str)
		{
			m_Tokenizer.Tokenize(str);

			List<Token> tokens = m_Tokenizer.Flush();
			int offset = 0;
			return ParseObject(tokens, ref offset);
		}

		private enum ParseObjectState
		{
			String = 0,
			KeySeparator = 1,
			Value = 2,
			Separator = 3
		}

		private JsonObject ParseObject(List<Token> tokens, ref int offset)
		{
			offset++;
			string key = "";

			ParseObjectState state = ParseObjectState.String;
			JsonObject obj = new JsonObject();
			for(int x = offset; x < tokens.Count; x++)
			{
				Token token = tokens[x];
				string tokenValue = token.Value.Trim();
				switch(state)
				{
					case ParseObjectState.String:
						if(token.Value.Length > 0)
						{
							if(token.IsSeparator)
							{
								if(token.Value == JsonConst.QUOTATION)
								{
									key = ParseString(tokens, ref x);
									state = ParseObjectState.KeySeparator;
								}
								else if(token.Value == JsonConst.BRACKETS_CLOSE)
								{
									offset = x;
									return obj;
								}
								else
								{
									throw new Exception(string.Format("While parsing object, found '{0}' but expected '{1}' or '{2}'",
										token.Value, JsonConst.QUOTATION, JsonConst.BRACKETS_CLOSE));
								}
							}
						}
						break;
					case ParseObjectState.KeySeparator:
						if(tokenValue.Length > 0)
						{
							if(token.IsSeparator && token.Value == JsonConst.KEY_VALUE_SEPARATOR)
							{
								state = ParseObjectState.Value;
							}
							else
							{
								throw new Exception(string.Format("While parsing key-value separator, found '{0}' but expected '{1}'",
									token.Value, JsonConst.KEY_VALUE_SEPARATOR));
							}
						}
						break;
					case ParseObjectState.Value:
						object value = ParseValue(tokens, ref x);
						obj.WriteObject(key, value);
						state = ParseObjectState.Separator;
						break;
					case ParseObjectState.Separator:
						if(tokenValue.Length > 0)
						{
							if(token.IsSeparator)
							{
								if(token.Value == JsonConst.BRACKETS_CLOSE)
								{
									offset = x;
									return obj;
								}
								else if(token.Value == JsonConst.SEPARATOR)
								{
									state = ParseObjectState.String;
								}
								else
								{
									throw new Exception(string.Format("While parsing object, found '{0}' but expected '{1}' or '{2}'",
										token.Value, JsonConst.QUOTATION, JsonConst.BRACKETS_CLOSE));
								}
							}
							else
							{
								throw new Exception(string.Format("While parsing object, found '{0}' but expected '{1}' or '{2}'",
									token.Value, JsonConst.SEPARATOR, JsonConst.BRACKETS_CLOSE));
							}
						}
						break;
				}
			}
			return obj;
		}

		private JsonArray ParseArray(List<Token> tokens, ref int offset)
		{
			bool isValue = true;
			offset++;
			JsonArray arr = new JsonArray(1);
			for(int x = offset; x < tokens.Count; x++)
			{
				Token token = tokens[x];
				if(isValue)
				{
					object value = ParseValue(tokens, ref x);
					arr.WriteObject(value);
					isValue = false;
				}
				else
				{
					string tokenValue = token.Value.Trim();
					if(tokenValue.Length > 0)
					{
						isValue = true;
						if(token.Value == JsonConst.ARRAY_CLOSE)
						{
							offset = x;
							return arr;
						}
						else if(token.Value != JsonConst.SEPARATOR && token.Value != JsonConst.ARRAY_CLOSE)
						{
							throw new Exception(string.Format("While parsing array value separator found '{0}' but expected '{1}' or '{2}'",
								token.Value, JsonConst.SEPARATOR, JsonConst.ARRAY_CLOSE));
						}
					}
				}

			}
			offset = tokens.Count;
			return arr;
		}


		private object ParseValue(List<Token> tokens, ref int offset)
		{
			for(int x = offset; x < tokens.Count; x++)
			{
				Token token = tokens[x];
				string trimmed = token.Value.Trim();
				if(trimmed.Length > 0)
				{
					offset = x;
					if(token.Value == JsonConst.QUOTATION)
					{
						return ParseString(tokens, ref offset);
					}
					else if(token.Value == JsonConst.ARRAY_OPEN)
					{
						return ParseArray(tokens, ref offset);
					}
					else if(token.Value == JsonConst.BRACKETS_OPEN)
					{
						return ParseObject(tokens, ref offset);
					}
					else if(char.IsNumber(trimmed[0]) || trimmed[0] == '-')
					{
						double result = double.Parse(trimmed, CultureInfo.InvariantCulture);
						return result;
					}
					else if(token.Value == "null")
					{
						return null;
					}
					else
					{
						bool value;
						if(bool.TryParse(token.Value, out value))
						{
							return value;
						}
						else
						{
							return null;
						}
					}
				}
			}
			offset = tokens.Count;
			return null;
		}

		private string ParseString(List<Token> tokens, ref int offset)
		{
			offset++;
			bool quoted = true;
			string result = "";
			for(int x = offset; x < tokens.Count; x++)
			{
				Token token = tokens[x];
				if(quoted)
				{
					if(!token.IsSeparator)
					{
						result += token.Value;
						quoted = false;
					}
					else if(token.Value != JsonConst.QUOTATION)
					{
						throw new Exception(string.Format("While parsing string, found '{0}' instead of closing quote: '{1}'",
							token.Value, JsonConst.QUOTATION));
					}
					else
					{
						offset = x;
						return "";
					}
				}
				else
				{
					if(!token.IsSeparator || token.Value != JsonConst.QUOTATION)
					{
						throw new Exception(string.Format("While parsing string, found '{0}' instead of closing quote: '{1}'", 
							token.Value, JsonConst.QUOTATION));
					}
					offset = x;
					return result;
				}
			}
			offset = tokens.Count;
			return "";
		}
	}
}
