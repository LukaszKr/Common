using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralLevel.Common.Parsing;

namespace CommonUnitTest.Parsing.JSON
{
    [TestClass]
	public class JsonObjectTest
	{
		[TestMethod]
		public void ToStringTest()
		{
			JsonObject obj = new JsonObject();
			Assert.AreEqual(obj.ToString(), "{}");

            obj.Write("ttrue", true);
            Assert.AreEqual(obj.ToString(), "{\"ttrue\":True}");

            obj = new JsonObject();
            obj.Write("nested", new JsonObject());
            Assert.AreEqual(obj.ToString(), "{\"nested\":{}}");
		}

        public void WriteReadTest()
        {
            JsonObject obj = new JsonObject();

            obj.Write("boolTest", true);
            Assert.AreEqual(obj.ReadBool("boolTest"), true);
        }
	}
}
