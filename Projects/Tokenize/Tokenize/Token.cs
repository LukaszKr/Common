namespace ProceduralLevel.Common.Tokenize
{
	public class Token
    {
		public readonly ETokenType Type;
		public readonly string Value;
		public readonly int Line;
		public readonly int Column;

		public bool IsSeparator { get { return Type == ETokenType.Separator; } }

		public Token(string value, ETokenType tokenType, int line, int column)
		{
			Value = value;
			Type = tokenType;
			Line = line;
			Column = column;
		}

		public override string ToString()
		{
			return string.Format("[Token][Value: '{0}', Type: {1} ({2},{3})]", Value, Type.ToString(), Line, Column);
		}
	}
}
