using ProceduralLevel.Common.Tokenize;
using System;

namespace ProceduralLevel.Common.Serialization.Json
{
	public class JsonParser: AParser<JsonObject>
	{
		public JsonParser() : base(new JsonTokenizer(true))
		{
		}

		protected override JsonObject Parse()
		{
			Token firstToken = PeekToken();
			AValue value = ParseValue();
			ObjectValue obj = value as ObjectValue;
			if(obj == null)
			{
				throw new JsonParserException(EJsonParserError.RootIsNotAnObject, firstToken);
			}
			return obj.Data;
		}

		private AValue ParseValue()
		{
			SkipToNextNonEmpty();
			Token token = PeekToken();
			switch(token.Value[0])
			{
				case JsonConst.BRACES_OPEN:
					ConsumeToken();
					return ParseObject();
				case JsonConst.ARRAY_OPEN:
					ConsumeToken();
					return ParseArray();
				case JsonConst.QUOTE:
					ConsumeToken();
					return ParseString();
				default:
					return ParseOther();
			}
			throw new JsonParserException(EJsonParserError.UnexpectedToken, token);
		}

		private AValue ParseObject()
		{
			JsonObject obj = new JsonObject();
			Token token = null;
			string key = null;
			AValue value = null;
			while(HasTokens())
			{
				token = PeekToken();
				if(key == null)
				{
					if(token.Value[0] == JsonConst.BRACES_CLOSE)
					{
						ConsumeToken();
						return new ObjectValue(obj);
					}
					AValue parsedKey = ParseValue();
					StringValue str = parsedKey as StringValue;
					if(str == null)
					{
						throw new JsonParserException(EJsonParserError.KeyIsNotString, token);
					}
					key = str.Data;
				}
				else if(value != null)
				{
					ConsumeToken();
					if(token.IsSeparator)
					{
						if(token.Value[0] == JsonConst.SEPARATOR)
						{
							key = null;
							value = null;
						}
						else if(token.Value[0] == JsonConst.BRACES_CLOSE)
						{
							return new ObjectValue(obj);
						}
						else
						{
							throw new JsonParserException(EJsonParserError.ExpectedSeparator, token);
						}
					}
					else if(!string.IsNullOrEmpty(token.Value))
					{
						throw new JsonParserException(EJsonParserError.ExpectedSeparator, token);

					}
				}
				else if(token.IsSeparator)
				{
					if(token.Value[0] == JsonConst.ASSIGN)
					{
						ConsumeToken();
						value = ParseValue();
						obj.Write(key, value);
					}
					else
					{
						throw new JsonParserException(EJsonParserError.ExpectedAssign, token);
					}
				}
				else if(!string.IsNullOrEmpty(token.Value))
				{
					throw new JsonParserException(EJsonParserError.ExpectedAssign, token);
				}

			}
			throw new JsonParserException(EJsonParserError.UnexpectedEnd, token);
		}

		private AValue ParseArray()
		{
			Token token = null;
			JsonArray arr = new JsonArray();
			bool emptyValue = false;
			while(HasTokens())
			{
				token = PeekToken();
				if(token.IsSeparator)
				{
					if(token.Value[0] == JsonConst.ARRAY_CLOSE)
					{
						ConsumeToken();
						return new ArrayValue(arr);
					}
					else if(token.Value[0] == JsonConst.SEPARATOR)
					{
						ConsumeToken();
						if(emptyValue)
						{
							arr.Write(new NullValue());
						}
						else
						{
							emptyValue = true;
						}
					}
					else
					{
						emptyValue = false;
						arr.Write(ParseValue());
					}
				}
				else
				{
					emptyValue = false;
					arr.Write(ParseValue());
				}
			}
			throw new JsonParserException(EJsonParserError.UnexpectedEnd, token);
		}

		private AValue ParseString()
		{
			Token token = null;
			string value = "";
			while(HasTokens())
			{
				token = ConsumeToken();
				if(token.IsSeparator)
				{
					if(token.Value[0] == JsonConst.QUOTE)
					{
						return new StringValue(value);
					}
					else
					{
						throw new JsonParserException(EJsonParserError.QuoteExpected, token);
					}
				}
				value += token.Value;
			}
			throw new JsonParserException(EJsonParserError.UnexpectedEnd, token);
		}

		private AValue ParseOther()
		{
			SkipToNextNonEmpty();
			Token token = ConsumeToken();
			if(token == null)
			{
				throw new JsonParserException(EJsonParserError.UnexpectedEnd, token);
			}
			if(token.IsSeparator)
			{
				throw new JsonParserException(EJsonParserError.UnexpectedToken, token);
			}
			if(bool.TryParse(token.Value, out bool bVal))
			{
				return new BoolValue(bVal);
			}
			if(token.Value.Contains(".") || token.Value.Contains(","))
			{
				return new NumberValue(token.Value);
				//double.Parse(token.Value, CultureInfo.InvariantCulture);
			}
			else if(char.IsNumber(token.Value[0]) && int.TryParse(token.Value, out int iVal))
			{
				return new NumberValue(token.Value);
			}
			else if(token.Value.Trim().Equals(NullValue.NULL, StringComparison.OrdinalIgnoreCase))
			{
				return new NullValue();
			}
			throw new JsonParserException(EJsonParserError.UnexpectedToken, token);
		}
	}
}
