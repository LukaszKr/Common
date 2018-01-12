using ProceduralLevel.Common.Tokenize;

namespace ProceduralLevel.Common.Serialization.Json
{
	public class JsonParserException: ParserException<EJsonParserError>
	{
		public JsonParserException(EJsonParserError errorCode, Token token) : base(errorCode, token)
		{
		}
	}
}
