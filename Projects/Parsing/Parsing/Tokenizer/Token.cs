namespace ProceduralLevel.Common.Parsing
{
	public class Token
    {
		public readonly ETokenType TokenType;
		public readonly string Value;
		public readonly int Position;

		public bool IsSeparator { get { return TokenType == ETokenType.Separator; } }

		public Token(string value, ETokenType tokenType, int position)
		{
			Value = value;
			TokenType = tokenType;
			Position = position;
		}

		public override string ToString()
		{
			return string.Format("[Token][{0}, Type: {1}, Position: {2}]", Value, TokenType, Position);
		}
	}
}
