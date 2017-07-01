using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralLevel.Serialization.CSV;

namespace Test.Serialization
{
	public static class TestHelper
	{
		public static void AssertCSVEntry(CSVEntry entry, params string[] values)
		{
			Assert.AreEqual(values.Length, entry.Size);
			for(int x = 0; x < values.Length; x++)
			{
				Assert.AreEqual(values[x], entry[x]);
			}
		}
	}
}
