using System;

namespace ProceduralLevel.Tokenize
{
	public class ParsingException<IDType>: Exception
	{
		public readonly IDType ID;
		public readonly Token Token;

		public ParsingException(IDType id, Token token)
		{
			ID = id;
			Token = token;
			Line = line;
		}
	}
}
