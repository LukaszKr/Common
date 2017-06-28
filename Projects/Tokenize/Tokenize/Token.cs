namespace ProceduralLevel.Tokenize
{
	public class Token
    {
		public readonly ETokenType TokenType;
		public readonly string Value;
		public readonly int Line;
		public readonly int Column;

		public bool IsSeparator { get { return TokenType == ETokenType.Separator; } }

		public Token(string value, ETokenType tokenType, int line, int column)
		{
			Value = value;
			TokenType = tokenType;
			Line = line;
			Column = column;
		}

		public override string ToString()
		{
			return string.Format("[Token][{0}, Type: {1} ({2},{3})]", Value, TokenType.ToString(), Line, Column);
		}
	}
}
