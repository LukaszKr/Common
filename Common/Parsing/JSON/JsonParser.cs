using System;
using System.Globalization;

namespace ProceduralLevel.Common.Parsing
{
	public class JsonParser: AParser<JsonObject>
    {

		public JsonParser()
			:base(new JSONTokenizer())
		{
		}

		private enum ParseObjectState
		{
			String = 0,
			KeySeparator = 1,
			Separator = 3
		}

		protected override JsonObject Parse()
		{
			ConsumeToken();
			return ParseObject();
		}

		private JsonObject ParseObject()
		{
			string key = "";

			ParseObjectState state = ParseObjectState.String;
			JsonObject obj = new JsonObject();
			while(HasTokens())
			{
				Token token = ConsumeToken();
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
									key = ParseString();
									state = ParseObjectState.KeySeparator;
								}
								else if(token.Value == JsonConst.BRACKETS_CLOSE)
								{
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
								object value = ParseValue();
								obj.WriteObject(key, value);
								state = ParseObjectState.Separator;
							}
							else
							{
								throw new Exception(string.Format("While parsing key-value separator, found '{0}' but expected '{1}'",
									token.Value, JsonConst.KEY_VALUE_SEPARATOR));
							}
						}
						break;
					case ParseObjectState.Separator:
						if(tokenValue.Length > 0)
						{
							if(token.IsSeparator)
							{
								if(token.Value == JsonConst.BRACKETS_CLOSE)
								{
									return obj;
								}
								else if(token.Value == JsonConst.SEPARATOR)
								{
									state = ParseObjectState.String;
								}
								else
								{
									throw new Exception(string.Format("While parsing object, found '{0}' but expected '{1}' or '{2}'",
										token.Value, JsonConst.SEPARATOR, JsonConst.BRACKETS_CLOSE));
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

		private JsonArray ParseArray()
		{
			bool isValue = true;
			JsonArray arr = new JsonArray(1);
			while(HasTokens())
			{
				if(isValue)
				{
					object value = ParseValue();
					arr.WriteObject(value);
					isValue = false;
				}
				else
				{
					Token token = ConsumeToken();
					string tokenValue = token.Value.Trim();
					if(tokenValue.Length > 0)
					{
						isValue = true;
						if(token.Value == JsonConst.ARRAY_CLOSE)
						{
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
			return arr;
		}


		private object ParseValue()
		{
			while(HasTokens())
			{
				Token token = ConsumeToken();
				string trimmed = token.Value.Trim();
				if(trimmed.Length > 0)
				{
					if(token.Value == JsonConst.QUOTATION)
					{
						return ParseString();
					}
					else if(token.Value == JsonConst.ARRAY_OPEN)
					{
						return ParseArray();
					}
					else if(token.Value == JsonConst.BRACKETS_OPEN)
					{
						return ParseObject();
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
			return null;
		}

		private string ParseString()
		{
			bool quoted = true;
			string result = "";
			while(HasTokens())
			{
				Token token = ConsumeToken();
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
					return JsonConst.UnescapeString(result);
				}
			}
			return "";
		}
	}
}
