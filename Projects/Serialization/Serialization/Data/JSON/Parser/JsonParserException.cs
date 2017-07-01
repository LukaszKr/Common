using ProceduralLevel.Tokenize;

namespace ProceduralLevel.Serialization.Json
{
	public class JsonParserException: ParserException<EJsonParserError>
	{
		public JsonParserException(EJsonParserError errorCode, Token token) : base(errorCode, token)
		{
		}
	}
}
