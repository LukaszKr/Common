using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralLevel.Serialization;
using ProceduralLevel.Serialization.Json;

namespace Test.Serialization.Json.Parser
{
	[TestClass]
	public class JsonParserTest
	{
		private JsonParser m_Parser;

		[TestInitialize]
		public void Initialize()
		{
			m_Parser = new JsonParser();
		}

		[TestMethod]
		public void EmptyObject()
		{
			JsonObject raw = new JsonObject();
			TestHelper.ParseAndAssert(m_Parser, raw);
		}

		[TestMethod]
		public void Primitives()
		{
			JsonObject raw = new JsonObject();
			WritePrimitives(raw);

			TestHelper.ParseAndAssert(m_Parser, raw);
		}

		[TestMethod]
		public void NestedObject()
		{
			JsonObject raw = new JsonObject();
			WriteNestedObject(raw);

			TestHelper.ParseAndAssert(m_Parser, raw);
		}

		[TestMethod]
		public void NestedArray()
		{
			JsonObject raw = new JsonObject();
			WriteNestedArray(raw);

			TestHelper.ParseAndAssert(m_Parser, raw);
		}

		[TestMethod]
		public void ComplexObject()
		{
			JsonObject raw = new JsonObject();
			WritePrimitives(raw);
			WriteNestedArray(raw);
			AObject nested = WriteNestedObject(raw);
			WriteNestedObject(nested);

			TestHelper.ParseAndAssert(m_Parser, raw);
		}

		private AObject WritePrimitives(AObject obj)
		{
			return obj.Write("b", true).Write("i", 123).Write("s", "123");
		}

		private AObject WriteNestedObject(AObject obj)
		{
			return WritePrimitives(obj.WriteObject("o"));
		}

		private AArray WriteNestedArray(AObject obj)
		{
			return obj.WriteArray("a").Write(true).Write(123).Write("str");
		}
	}
}
