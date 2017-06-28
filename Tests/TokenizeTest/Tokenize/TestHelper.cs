using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralLevel.Tokenize;

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
	}
}
