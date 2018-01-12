namespace ProceduralLevel.Common.Serialization.Json
{
	public enum EJsonParserError
	{
		RootIsNotAnObject,
		UnexpectedToken,
		UnexpectedEnd,
		KeyIsNotString,
		ExpectedAssign,
		QuoteExpected,
		ExpectedSeparator,
	}
}
