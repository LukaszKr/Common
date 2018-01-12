using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralLevel.Common.Serialization.CSV;

namespace Test.Serialization.CSV.Parser
{
    [TestClass]
	public class CSVParserTest
	{
		protected CSVParser m_Parser;

		[TestInitialize]
		public void Initialize()
		{
			m_Parser = new CSVParser();
		}

		[TestMethod]
		public void SimpleFromString()
		{
			CSVObject csv = m_Parser.Parse("").Flush();
			Assert.IsNull(csv);
		}

		[TestMethod]
		public void Columns()
		{
			CSVObject csv = m_Parser.Parse("123,\"hello\"").Flush();
			Assert.AreEqual(2, csv.Width);
			CSVEntry entry = csv.Header;
			TestHelper.AssertCSVEntry(entry, "123", "hello");
		}

		[TestMethod]
		public void QuotesInValue()
		{
			CSVObject csv = m_Parser.Parse("\"\"hello\"\"").Flush();
			Assert.AreEqual(1, csv.Width);
			CSVEntry entry = csv.Header;
			TestHelper.AssertCSVEntry(entry, "\"hello\"");
		}

		[TestMethod]
		public void MultipleColumns()
		{
			CSVObject csv = m_Parser.Parse("hello,world").Flush();
			TestHelper.AssertCSVEntry(csv.Header, "hello", "world");
		}

		[TestMethod]
		public void MultipleQuotedColumns()
		{
			CSVObject csv = m_Parser.Parse("\"hello\",\"world\"").Flush();
			TestHelper.AssertCSVEntry(csv.Header, "hello", "world");
		}
	}
}
