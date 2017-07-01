using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralLevel.Serialization.CSV;

namespace Test.Serialization.CSV
{
	[TestClass]
	public class CSVEscapeTest
	{
		[TestMethod]
		public void EscapeNeutralStrings()
		{
			string str = "hello;world";
			Assert.AreEqual(str, CSVConst.EscapeString(str));
			Assert.AreEqual(str, CSVConst.UnEscapeString(str));
		}

		[TestMethod]
		public void EscapeQuotation()
		{
			string str = "\"hello\";world";
			string escaped = "\"\"hello\"\";world";
			Assert.AreEqual(escaped, CSVConst.EscapeString(str));
			Assert.AreEqual(str, CSVConst.UnEscapeString(escaped));
		}

		[TestMethod]
		public void UnEscapeQuoted()
		{
			string str = "\"hello\";world";
			Assert.AreEqual(str, CSVConst.UnEscapeString(str));

			str = "\"hello\"";
			Assert.AreEqual("\"hello\"", CSVConst.UnEscapeString(str));
		}
	}
}
