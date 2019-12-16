using NUnit.Framework;
using ProceduralLevel.Common.Serialization.CSV;

namespace ProceduralLevel.Common.Tests.Serialization.CSV
{
	[TestFixture]
	public class CSVTest
	{
		private CSVParser m_Parser;

		[SetUp]
		public void Initialize()
		{
			m_Parser = new CSVParser();
		}

		[Test]
		public void EmptyString()
		{
			CSVTable table = m_Parser.Parse("").Flush();

			Assert.AreEqual(0, table.Entries.Count);
		}

		[Test]
		public void SingleEntry()
		{
			CSVTable table = m_Parser.Parse("a;b").Flush();

			Assert.AreEqual(1, table.Entries.Count);
			CSVEntry entry = table.Entries[0];
			Assert.AreEqual(2, entry.Values.Length);
			Assert.AreEqual("a", entry.Values[0]);
			Assert.AreEqual("b", entry.Values[1]);
		}
	}
}
