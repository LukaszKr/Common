using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralLevel.Common.Tokenize;
using System.Collections.Generic;

namespace Test.Tokenize
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
		public void BasicHelloWorld()
		{
			List<Token> tokens = m_Tokenizer.Tokenize("hello, world!").Flush();

			AssertHelloWorld(tokens);
		}

		[TestMethod]
		public void MultiPartTokenize()
		{
			List<Token> tokens = m_Tokenizer.Tokenize("hello, ").Tokenize("world").Tokenize("!").Flush();
			AssertHelloWorld(tokens);
		}


		private void AssertHelloWorld(List<Token> tokens)
		{
			Assert.AreEqual(5, tokens.Count);
			TestHelper.AssertToken(tokens[0], ETokenType.Value, "hello", 0, 0);
			TestHelper.AssertToken(tokens[1], ETokenType.Separator, ",", 0, 5);
			TestHelper.AssertToken(tokens[2], ETokenType.Separator, " ", 0, 6);
			TestHelper.AssertToken(tokens[3], ETokenType.Value, "world", 0, 7);
			TestHelper.AssertToken(tokens[4], ETokenType.Separator, "!", 0, 12);
		}
	}
}
