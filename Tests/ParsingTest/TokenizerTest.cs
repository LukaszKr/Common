using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralLevel.Tokenize;
using System.Collections.Generic;

namespace ParsingTest.Tokenizer
{
	[TestClass]
	public class TokenizerTest
	{
		private SimpleTokenizer m_Tokenizer;

		[TestInitialize]
		public void Initialize()
		{
			m_Tokenizer = new SimpleTokenizer(',', ' ', '!');
		}

		[TestMethod]
		public void SimpleTest()
		{
			List<Token> tokens = m_Tokenizer.Tokenize("hello, world!").Flush();
			
			Assert.AreEqual(5, tokens.Count);
			TestHelper.AssertToken(tokens[0], ETokenType.Value, "hello", 0, 0);
			TestHelper.AssertToken(tokens[1], ETokenType.Separator, ",", 0, 5);
			TestHelper.AssertToken(tokens[2], ETokenType.Separator, " ", 0, 6);
			TestHelper.AssertToken(tokens[3], ETokenType.Value, "world", 0, 7);
			TestHelper.AssertToken(tokens[4], ETokenType.Separator, "!", 0, 12);
		}
	}
}
