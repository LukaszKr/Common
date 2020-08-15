using ProceduralLevel.Common.Tokenize;

namespace ProceduralLevel.Common.Template.Parser
{
	public class TemplateParserException: ParserException<ETemplateParserError>
	{
		public TemplateParserException(ETemplateParserError errorCode, Token token)
			: base(errorCode, token)
		{
		}
	}
}
