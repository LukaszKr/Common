﻿namespace ProceduralLevel.Common.Parsing
{
	public class Token
    {
		public bool IsSeparator { get; private set; }
		public string Value { get; private set; }

		public Token(string value, bool isSeparator)
		{
			Value = value;
			IsSeparator = isSeparator;
		}

		public override string ToString()
		{
			return string.Format("[Token][{0}, Separator: {1}]", Value, IsSeparator);
		}
	}
}
