using ProceduralLevel.Tokenize;

namespace ProceduralLevel.Template.Parser
{
	public class TemplateParserException: ParserException<ETemplateParserError>
	{
		public TemplateParserException(ETemplateParserError errorCode, Token token) : base(errorCode, token)
		{
		}
	}
}
