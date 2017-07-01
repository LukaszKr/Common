using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralLevel.Serialization.CSV;

namespace Test.Serialization.CSV
{
	[TestClass]
	public class CSVObjectTest
	{
		protected CSVObject m_CSV;

		[TestInitialize]
		public void Initialize()
		{
			m_CSV = new CSVObject();
		}

		[TestMethod]
		public void BasicToString()
		{
			Assert.AreEqual("", m_CSV.ToString());
			
			m_CSV.Resize(2);
			Assert.AreEqual(CSVConst.SEPARATOR.ToString(), m_CSV.ToString());

			CSVEntry entry = m_CSV.Header;
			entry[0] = "hello";
			entry[1] = "123";
			Assert.AreEqual("\"hello\",\"123\"", m_CSV.ToString());
		}

		[TestMethod]
		public void AddColumn()
		{
			m_CSV.AddHeader("test");
			Assert.AreEqual(1, m_CSV.Header.Size);
			m_CSV.AddHeader("test");
			Assert.AreEqual(1, m_CSV.Header.Size);
			m_CSV.AddHeaders("test", "test2");
			TestHelper.AssertCSVEntry(m_CSV.Header, "test" ,"test2");
		}
	}
}
