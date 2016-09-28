using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralLevel.Common.Parsing;
using System.IO;

namespace CommonUnitTest.Parsing.JSON
{
    [TestClass]
    public class JsonParserTest
    {
        private JsonObject m_Object;

        [TestInitialize()]
        public void Initialize()
        {
            JsonParser parser = new JsonParser();
            string json = File.ReadAllText("testData/json/typeParsing.json");

            m_Object = parser.Parse(json);
        }

        [TestMethod]
        public void PrimitiveTest()
        {
            Assert.AreEqual(true, m_Object.ReadBool("bool"));
            Assert.AreEqual(1, m_Object.ReadInt("integer"));
            Assert.AreEqual(2.5f, m_Object.ReadFloat("float"));
            Assert.AreEqual("str", m_Object.ReadString("string"));
        }

        [TestMethod]
        public void NestedObjectTest()
        {
            JsonObject nested = m_Object.ReadObject("nested");
            Assert.IsNotNull(nested);
            Assert.AreEqual("world", nested.ReadString("hello"));
        }

        [TestMethod]
        public void NestedArrayTest()
        {
            JsonArray array = m_Object.ReadArray("array");
            Assert.AreEqual(3, array.Count);
            for(int x = 0; x < array.Count; x++)
            {
                Assert.AreEqual(x+1, array.ReadInt(x));
            }

            array = m_Object.ReadArray("strArray");
            Assert.AreEqual(3, array.Count);
            Assert.AreEqual("a", array.ReadString(0));
            Assert.AreEqual("b", array.ReadString(1));
            Assert.AreEqual("c", array.ReadString(2));

            array = m_Object.ReadArray("mixedArray");
            Assert.AreEqual(3, array.Count);
            Assert.AreEqual(true, array.ReadBool(0));
            Assert.AreEqual("a", array.ReadString(1));
            Assert.AreEqual(1, array.ReadInt(2));
        }
    }
}
