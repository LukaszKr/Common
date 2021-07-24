using System;

namespace ProceduralLevel.Common.Tokenize
{
	public class ParserException<ErrorIDType> : Exception
	{
		public readonly ErrorIDType ErrorCode;
		public readonly Token Token;

		public ParserException(ErrorIDType errorCode, Token token)
		{
			ErrorCode = errorCode;
			Token = token;
		}

		public override string ToString()
		{
			return string.Format("[{0} {1}]", ErrorCode.ToString(), (Token != null ? Token.ToString() : "-"));
		}
	}
}
