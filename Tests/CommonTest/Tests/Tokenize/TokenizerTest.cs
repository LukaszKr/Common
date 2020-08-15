using NUnit.Framework;
using ProceduralLevel.Common.Tokenize;
using System.Collections.Generic;

namespace Tests.Tokenize
{
	[TestFixture]
	public class TokenizerTest
	{
		private SimpleTokenizer m_Tokenizer;

		[SetUp]
		public void Initialize()
		{
			m_Tokenizer = new SimpleTokenizer(',', ' ', '!');
		}

		[Test]
		public void BasicHelloWorld()
		{
			List<Token> tokens = m_Tokenizer.Tokenize("hello, world!").Flush();

			AssertHelloWorld(tokens);
		}

		[Test]
		public void MultiPartTokenize()
		{
			List<Token> tokens = m_Tokenizer.Tokenize("hello, ").Tokenize("world").Tokenize("!").Flush();
			AssertHelloWorld(tokens);
		}


		private void AssertHelloWorld(List<Token> tokens)
		{
			Assert.AreEqual(5, tokens.Count);
			TokenizerTestHelper.AssertToken(tokens[0], ETokenType.Value, "hello", 0, 0);
			TokenizerTestHelper.AssertToken(tokens[1], ETokenType.Separator, ",", 0, 5);
			TokenizerTestHelper.AssertToken(tokens[2], ETokenType.Separator, " ", 0, 6);
			TokenizerTestHelper.AssertToken(tokens[3], ETokenType.Value, "world", 0, 7);
			TokenizerTestHelper.AssertToken(tokens[4], ETokenType.Separator, "!", 0, 12);
		}
	}
}
