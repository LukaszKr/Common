using System.Collections.Generic;
using NUnit.Framework;
using ProceduralLevel.Common.Tokenize;

namespace Tests.Tokenize.Escape
{
	[TestFixture]
	public class TokenEscapeTest
	{
		private SimpleTokenizer m_Tokenizer;

		[SetUp]
		public void Initialize()
		{
			m_Tokenizer = new SimpleTokenizer(',', ' ', '!');
		}

		[Test]
		public void SimpleEscape()
		{
			List<Token> tokens = m_Tokenizer.Tokenize("hello\\, world\\!").Flush();

			Assert.AreEqual(3, tokens.Count);
			TokenizerTestHelper.AssertToken(tokens[0], ETokenType.Value, "hello,", 0, 0);
			TokenizerTestHelper.AssertToken(tokens[1], ETokenType.Separator, " ", 0, 6);
			TokenizerTestHelper.AssertToken(tokens[2], ETokenType.Value, "world!", 0, 7);
		}

		[Test]
		public void EscapeCharAtTheEnd()
		{
			List<Token> tokens = m_Tokenizer.Tokenize("hello\\").Flush();

			Assert.AreEqual(1, tokens.Count);
			TokenizerTestHelper.AssertToken(tokens[0], ETokenType.Value, "hello");
		}

		[Test]
		public void EscapeCharAtBeggining()
		{
			List<Token> tokens = m_Tokenizer.Tokenize("\\hello").Flush();

			Assert.AreEqual(1, tokens.Count);
			TokenizerTestHelper.AssertToken(tokens[0], ETokenType.Value, "hello");
		}

		[Test]
		public void EscapeAnEscape()
		{
			List<Token> tokens = m_Tokenizer.Tokenize("\\\\").Flush();

			Assert.AreEqual(1, tokens.Count);
			TokenizerTestHelper.AssertToken(tokens[0], ETokenType.Value, "\\");
		}
	}
}
