namespace ProceduralLevel.Common.Template
{
	public enum ETemplateParserError
	{
		UnexpectedToken = 0,

		TemplateName_IllegalCharacter = 10,
		TemplateName_IllegalFormat = 11,

		Context_InvalidGlobalUse = 20,

		Method_IncorrectName = 30
	}
}
