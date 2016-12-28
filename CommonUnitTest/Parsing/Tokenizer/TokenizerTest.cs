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
            Tokenizer tokenizer = new SimpleTokenizer(",", " ");
            tokenizer.Tokenize("a, b");
            List<Token> tokens = tokenizer.Flush();
            AssertToken(tokens[0], false, "a");
            AssertToken(tokens[1], true, ",");
            AssertToken(tokens[2], true, " ");
            AssertToken(tokens[3], false, "b");
        }

        private void AssertToken(Token token, bool isSeparator, string value)
        {
            Assert.AreEqual(isSeparator, token.IsSeparator);
            Assert.AreEqual(value, token.Value);
        }
    }
}
