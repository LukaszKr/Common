using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralLevel.Common.Tokenize;
using System.Collections.Generic;

namespace ProceduralLevel.Common.Tests.Tokenize.Escape
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
			TokenizerTestHelper.AssertToken(tokens[0], ETokenType.Value, "hello,", 0, 0);
			TokenizerTestHelper.AssertToken(tokens[1], ETokenType.Separator, " ", 0, 6);
			TokenizerTestHelper.AssertToken(tokens[2], ETokenType.Value, "world!", 0, 7);
		}

		[TestMethod]
		public void EscapeCharAtTheEnd()
		{
			List<Token> tokens = m_Tokenizer.Tokenize("hello\\").Flush();

			Assert.AreEqual(1, tokens.Count);
			TokenizerTestHelper.AssertToken(tokens[0], ETokenType.Value, "hello");
		}

		[TestMethod]
		public void EscapeCharAtBeggining()
		{
			List<Token> tokens = m_Tokenizer.Tokenize("\\hello").Flush();

			Assert.AreEqual(1, tokens.Count);
			TokenizerTestHelper.AssertToken(tokens[0], ETokenType.Value, "hello");
		}

		[TestMethod]
		public void EscapeAnEscape()
		{
			List<Token> tokens = m_Tokenizer.Tokenize("\\\\").Flush();

			Assert.AreEqual(1, tokens.Count);
			TokenizerTestHelper.AssertToken(tokens[0], ETokenType.Value, "\\");
		}
	}
}
