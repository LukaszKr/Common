using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralLevel.Serialization;
using ProceduralLevel.Serialization.Json;

namespace Test.Serialization.Json.Array
{
	[TestClass]
	public class JsonArrayTest: AArrayTest<JsonArray>
	{
		protected override AArray CreateArray()
		{
			return new JsonArray();
		}
	}
}
