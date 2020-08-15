using NUnit.Framework;
using ProceduralLevel.Common.Serialization.CSV;

namespace Tests.Serialization.CSV
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
			AssertEntry(entry, "a", "b");
		}

		[Test]
		public void KeyValuePair()
		{
			CSVTable table = m_Parser.Parse("key;value").Flush();
			AssertEntry(table.Entries[0], "key", "value");
		}

		[Test]
		public void QuotedValues()
		{
			CSVTable table = m_Parser.Parse("\"key\";\"value\"").Flush();
			AssertEntry(table.Entries[0], "key", "value");
		}

		[Test]
		public void MultiLineValue()
		{
			CSVTable table = m_Parser.Parse("\"key\";\"value\nvalue\"").Flush();
			AssertEntry(table.Entries[0], "key", "value\nvalue");
		}

		[Test]
		public void MultipleEntries()
		{
			CSVTable table = m_Parser.Parse("\"key1\";\"value1\"\nkey2;value2").Flush();
			AssertEntry(table.Entries[0], "key1", "value1");
			AssertEntry(table.Entries[1], "key2", "value2");
		}

		[Test]
		public void MixedSeparators()
		{
			CSVTable table = m_Parser.Parse("1;2,3").Flush();
			AssertEntry(table.Entries[0], "1", "2,3");

			table = m_Parser.Parse("1,2;3").Flush();
			AssertEntry(table.Entries[0], "1", "2;3");
		}

		[Test]
		public void PutInQuotesIfNeeded()
		{
			CSVEntry entry = new CSVEntry("1,2", "3");
			string strEntry = entry.ToString(',');
			Assert.AreEqual("\"1,2\",3", strEntry);
		}

		private static void AssertEntry(CSVEntry entry, params string[] values)
		{
			int length = values.Length;
			Assert.AreEqual(length, entry.Values.Length);

			for(int x = 0; x < length; ++x)
			{
				Assert.AreEqual(values[x], entry.Values[x]);
			}
		}
	}
}
