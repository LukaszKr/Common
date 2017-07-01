using ProceduralLevel.Tokenize;

namespace ProceduralLevel.Serialization.CSV
{
	public class CSVParserException: ParserException<ECSVParserError>
	{
		public CSVParserException(ECSVParserError id, Token token) : base(id, token)
		{
		}
	}
}
