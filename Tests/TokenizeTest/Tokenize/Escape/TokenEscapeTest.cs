using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralLevel.Tokenize;
using System.Collections.Generic;

namespace Test.Tokenize.Escape
{
	[TestClass]
	public class TokenEscapeTest
	{
		private SimpleTokenizer m_Tokenizer;

		[TestInitialize]
		public void Initialize()
		{
			m_Tokenizer = new SimpleTokenizer(',', ' ', '!');
		}

		[TestMethod]
		public void SimpleEscape()
		{
			List<Token> tokens = m_Tokenizer.Tokenize("hello\\, world\\!").Flush();

			Assert.AreEqual(3, tokens.Count);
			TestHelper.AssertToken(tokens[0], ETokenType.Value, "hello,", 0, 0);
			TestHelper.AssertToken(tokens[1], ETokenType.Separator, " ", 0, 6);
			TestHelper.AssertToken(tokens[2], ETokenType.Value, "world!", 0, 7);
		}

		[TestMethod]
		public void EscapeCharAtTheEnd()
		{
			List<Token> tokens = m_Tokenizer.Tokenize("hello\\").Flush();
			
			Assert.AreEqual(1, tokens.Count);
			TestHelper.AssertToken(tokens[0], ETokenType.Value, "hello");
		}
	}
}
