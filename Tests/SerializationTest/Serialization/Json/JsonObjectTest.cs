using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralLevel.Serialization;
using ProceduralLevel.Serialization.Json;

namespace Test.Serialization.Json.Object
{
	[TestClass]
	public class JsonObjectTest: AObjectTest<JsonObject>
	{
		protected override AObject CreateObject()
		{
			return new JsonObject();
		}
	}
}
