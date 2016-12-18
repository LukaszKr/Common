namespace ProceduralLevel.Common.Parsing
{
	public class Token
    {
		public readonly ETokenType TokenType;
		public readonly string Value;

		public bool IsSeparator { get { return TokenType == ETokenType.Separator; } }

		public Token(string value, ETokenType tokenType)
		{
			Value = value;
			TokenType = tokenType;
		}

		public override string ToString()
		{
			return string.Format("[Token][{0}, Type: {1}]", Value, TokenType);
		}
	}
}
