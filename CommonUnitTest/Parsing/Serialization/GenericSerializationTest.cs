using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralLevel.Common.Serialization;

namespace ProceduralLevel.CommonUnitTest.Parsing
{
	public class SimpleClass
	{
		public int ID = 3;
		public string Name = "test";
	}

	[TestClass]
	public class GenericSerializationTest
	{
		[TestInitialize()]
		public void Initialize()
		{

		}

		[TestMethod]
		public void SerializeTest()
		{
			SimpleClass test = new SimpleClass();
			JsonObjectSerializer serializer = new JsonObjectSerializer();
			Serializer.Serialize(test, serializer);
			Assert.AreEqual(3, serializer.Object.ReadInt("ID"));
			Assert.AreEqual("test", serializer.Object.ReadString("Name"));
		}
	}
}
