﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralLevel.Tokenize;
using System.Collections.Generic;

namespace Test.Tokenize
{
	public static class TestHelper
	{
		public static void AssertToken(Token token, ETokenType type, string value, int line = -1, int column = -1)
		{
			Assert.AreEqual(type, token.Type);
			Assert.AreEqual(value, token.Value);
			if(line >= 0)
			{
				Assert.AreEqual(line, token.Line);
			}
			if(column >= 0)
			{
				Assert.AreEqual(column, token.Column);
			}
		}

		public static void AssertTokenValues(List<Token> tokens, params string[] values)
		{
			for(int x = 0; x < tokens.Count; x++)
			{
				Token token = tokens[x];
				Assert.AreEqual(values[x], token.Value);
			}
		}

		public static void AssertTokenTypes(List<Token> tokens, params ETokenType[] types)
		{
			for(int x = 0; x < tokens.Count; x++)
			{
				Token token = tokens[x];
				Assert.AreEqual(types[x], token.Type);
			}
		}
	}
}
