﻿namespace ProceduralLevel.Common.Template.Parser
{
	public enum ETemplateParserError
	{
		UnexpectedToken = 0,

		TemplateName_IllegalCharacter = 10,
		TemplateName_IllegalFormat = 11,

		Context_InvalidGlobalUse = 20
	}
}
