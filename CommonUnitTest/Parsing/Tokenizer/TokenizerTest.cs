using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralLevel.Common.Parsing;
using System.Collections.Generic;

namespace ProceduralLevel.CommonUnitTest.Parsing
{
	[TestClass]
    public class TokenizerTest
    {
        [TestInitialize()]
        public void Initialize()
        {

        }

        [TestMethod()]
        public void SimpleCase()
        {
            ATokenizer tokenizer = new SimpleTokenizer(null, ",", " ");
            tokenizer.Tokenize("a, b");
            List<Token> tokens = tokenizer.Flush();
            AssertToken(tokens[0], false, "a");
            AssertToken(tokens[1], true, ",");
            AssertToken(tokens[2], true, " ");
            AssertToken(tokens[3], false, "b");
        }

		[TestMethod]
		public void EscapedSeparator()
		{
			ATokenizer tokenizer = new SimpleTokenizer("\\", ",");
			tokenizer.Tokenize("a,\\,b");
			List<Token> tokens = tokenizer.Flush();
			Assert.AreEqual(3, tokens.Count);
			AssertToken(tokens[0], false, "a");
			AssertToken(tokens[1], true, ",");
			AssertToken(tokens[2], false, ",b");
		}

		[TestMethod]
		public void EscapedAtTheEnd()
		{
			ATokenizer tokenizer = new SimpleTokenizer("\\", ",");
			tokenizer.Tokenize("a,\\,");
			List<Token> tokens = tokenizer.Flush();
			Assert.AreEqual(3, tokens.Count);
			AssertToken(tokens[0], false, "a");
			AssertToken(tokens[1], true, ",");
			AssertToken(tokens[2], false, ",");
		}

		[TestMethod]
		public void EscapedAndEnclosed()
		{
			ATokenizer tokenizer = new SimpleTokenizer("\\", ",");
			tokenizer.Tokenize("\\,value\\,");
			List<Token> tokens = tokenizer.Flush();
			Assert.AreEqual(1, tokens.Count);
			AssertToken(tokens[0], false, ",value,");
		}

        private void AssertToken(Token token, bool isSeparator, string value)
        {
            Assert.AreEqual(isSeparator, token.IsSeparator);
            Assert.AreEqual(value, token.Value);
        }
    }
}
