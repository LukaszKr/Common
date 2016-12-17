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
			int offset = 1;
			return ParseObject(tokens, ref offset);
		}

		private enum ObjectParseState
		{
			Key,
			KeyValueSeparator,
			Value,
			ObjectValue,
			ArrayValue,
			PostValue
		}

		private JsonObject ParseObject(List<Token> tokens, ref int offset)
		{
			JsonObject obj = new JsonObject();
			ObjectParseState parseState = ObjectParseState.Key;
			string key = null;

			for(int x = offset; x < tokens.Count; x++)
			{
				Token token = tokens[x];
				switch(parseState)
				{
					case ObjectParseState.Key:
						key = ParseString(tokens, ref x);
						parseState = ObjectParseState.KeyValueSeparator;
						break;
					case ObjectParseState.KeyValueSeparator:
						if(token.IsSeparator && token.Value == JsonConst.KEY_VALUE_SEPARATOR)
						{
							parseState = ObjectParseState.Value;
						}
						else
						{
							throw new Exception(string.Format("Expected '{0}' but found {1} when parsing pair separator.", 
								JsonConst.KEY_VALUE_SEPARATOR, token.Value));
						}
						break;
					case ObjectParseState.Value:
						if(token.IsSeparator)
						{
							if(token.Value == JsonConst.BRACKETS_OPEN)
							{
								parseState = ObjectParseState.ObjectValue;
							}
							else if(token.Value == JsonConst.ARRAY_OPEN)
							{
								parseState = ObjectParseState.ArrayValue;
							}
							else if(token.Value == JsonConst.QUOTATION)
							{
								obj.Write(key, ParseString(tokens, ref x));
								parseState = ObjectParseState.PostValue;
							}
							else
							{
								throw new Exception(string.Format("Expected object value and '{0}' or '{1}' as separator but found {2}",
									JsonConst.BRACKETS_OPEN, JsonConst.ARRAY_OPEN, token.Value));
							}
						}
						else
						{
                            if(char.IsNumber(token.Value[0]) || token.Value[0] == '-')
                            {
                                obj.Write(key, ParseNumerical(token));
                            }
                            else
                            {
                                obj.Write(key, ParseBoolean(token));
                            }
							parseState = ObjectParseState.PostValue;
						}
						break;
					case ObjectParseState.ObjectValue:
						obj.Write(key, ParseObject(tokens, ref x));
						parseState = ObjectParseState.PostValue;
						break;
					case ObjectParseState.ArrayValue:
						obj.Write(key, ParseArray(tokens, ref x));
						parseState = ObjectParseState.PostValue;
						break;
					case ObjectParseState.PostValue:
						if(token.IsSeparator && token.Value == JsonConst.BRACKETS_CLOSE)
						{
							offset = x;
							return obj;
						}
						else if(token.IsSeparator && token.Value == JsonConst.SEPARATOR)
						{
							parseState = ObjectParseState.Key;
						}
						else
						{
							throw new Exception(string.Format("Expected '{0}' or '{1}' after pair value, but found {1}",
								JsonConst.SEPARATOR, JsonConst.BRACKETS_CLOSE, token.Value));
						}
						key = null;
						break;
				}
			}

			throw new Exception("Unexpected end of object.");
		}

		private enum ArrayParseState
		{
			Value,
			PostValue
		}

		private JsonArray ParseArray(List<Token> tokens, ref int offset)
		{
			JsonArray array = new JsonArray(4);
			ArrayParseState parseState = ArrayParseState.Value;

			for(int x = offset; x < tokens.Count; x++)
			{
				Token token = tokens[x];

				switch(parseState)
				{
					case ArrayParseState.Value:
						if(!token.IsSeparator)
						{
                            if(char.IsNumber(token.Value[0]) || token.Value[0] == '-')
                            {
                                array.Write(ParseNumerical(token));
                            }
                            else
                            {
                                array.Write(ParseBoolean(token));
                            }
                            parseState = ArrayParseState.PostValue;
						}
						else
						{
							if(token.Value == JsonConst.BRACKETS_OPEN)
							{
								x++;
								array.Write(ParseObject(tokens, ref x));
								parseState = ArrayParseState.PostValue;
							}
							else if(token.Value == JsonConst.ARRAY_OPEN)
							{
								x++;
								array.Write(ParseArray(tokens, ref x));
								parseState = ArrayParseState.PostValue;
							}
							else if(token.Value == JsonConst.QUOTATION)
							{
								array.Write(ParseString(tokens, ref x));
								parseState = ArrayParseState.PostValue;
							}
						}
						break;
					case ArrayParseState.PostValue:
						if(token.IsSeparator && token.Value == JsonConst.SEPARATOR)
						{
							parseState = ArrayParseState.Value;
						}
						else if(token.IsSeparator && token.Value == JsonConst.ARRAY_CLOSE)
						{
							offset = x;
							return array;
						}
						else
						{
							throw new Exception(string.Format("Expected '{0}' or '{1}' when parsing array separator but found {2}",
								JsonConst.SEPARATOR, JsonConst.ARRAY_CLOSE, token.Value));
						}
						break;
				}
			}

			throw new Exception("Unexpected end of array.");
		}

        private bool ParseBoolean(Token token)
        {
            bool value;
            if(!bool.TryParse(token.Value, out value))
            {
                throw new Exception(string.Format("Expected True|False but found {0}", 
                    token.Value));
            }
            return value;
        }

		private double ParseNumerical(Token token)
		{
			double value;
			if(!double.TryParse(token.Value, NumberStyles.Any , CultureInfo.InvariantCulture, out value))
			{
				throw new Exception(string.Format("Expected numerical value but found {0}",
					token.Value));
			}
			return value;
		}

		private enum ParseStringState
		{
			StartQuote,
			Value,
			EndQuote
		}

		private string ParseString(List<Token> tokens, ref int offset)
		{
			string value = "";
			ParseStringState parseState = ParseStringState.StartQuote;

			for(int x = offset; x < tokens.Count; x++)
			{
				Token token = tokens[x];
				switch(parseState)
				{
					case ParseStringState.StartQuote:
						if(!token.IsSeparator || token.Value != JsonConst.QUOTATION)
						{
							throw new Exception(string.Format("Expected '{0}' but found '{1}'",
								JsonConst.QUOTATION, token.Value));
						}
						parseState = ParseStringState.Value;
						break;
					case ParseStringState.Value:
						if(token.IsSeparator)
						{
							throw new Exception("Found separator while expecting value.");
						}
						value = token.Value;
						parseState = ParseStringState.EndQuote;
						break;
					case ParseStringState.EndQuote:
						if(!token.IsSeparator || token.Value != JsonConst.QUOTATION)
						{
							throw new Exception(string.Format("Expected '{0}' but found '{1}'",
								JsonConst.QUOTATION, token.Value));
						}
						offset = x;
						return value;
				}
			}
			
			throw new Exception("Unexpected end while parsing string.");
		}
    }
}
