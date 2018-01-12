using ProceduralLevel.Common.Tokenize;

namespace ProceduralLevel.Common.Serialization.CSV
{
	public class CSVParserException: ParserException<ECSVParserError>
	{
		public CSVParserException(ECSVParserError id, Token token) : base(id, token)
		{
		}
	}
}
