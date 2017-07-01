using System;

namespace ProceduralLevel.Tokenize
{
	public class ParserException<IDType>: Exception
	{
		public readonly IDType ID;
		public readonly Token Token;

		public ParserException(IDType id, Token token)
		{
			ID = id;
			Token = token;
		}
	}
}
