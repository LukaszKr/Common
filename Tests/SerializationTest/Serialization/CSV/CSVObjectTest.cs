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
			CSVEntry entry = new CSVEntry(2);
			m_CSV.Add(entry);
			Assert.AreEqual(CSVConst.SEPARATOR.ToString(), m_CSV.ToString());

			entry[0] = "hello";
			entry[1] = "123";
			Assert.AreEqual("\"hello\",\"123\"", m_CSV.ToString());
		}
	}
}
