using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralLevel.Common.Parsing;
using System.IO;

namespace ProceduralLevel.CommonUnitTest.Parsing
{
	[TestClass]
    public class CSVTest
    {
        private CSV m_Example;

        [TestInitialize]
        public void Initialize()
        {
            CSVParser parser = new CSVParser();

            string example = File.ReadAllText("testData/csv/example.csv");
			parser.Parse(example);
			m_Example = parser.Flush();
        }

        [TestMethod]
        public void HeaderTest()
        {
			Assert.AreEqual(4, m_Example.Header.Length);
            for(int x = 0; x < 4; x++)
            {
                Assert.AreEqual("col"+(x+1), m_Example.Header[x]);
            }
        }
        
		[TestMethod]
		public void SimpleCSV()
		{
			CSVParser parser = new CSVParser();
			string sample = File.ReadAllText("testData/csv/live.csv");
			parser.Parse(sample);
			CSV csv = parser.Flush();
		}

        /// <summary>
        /// When value is something like "a, b" space in middle would get removed.
        /// </summary>
        [TestMethod]
        public void SpacesTest()
        {
            CSVParser parser = new CSVParser();
            string example = File.ReadAllText("testData/csv/space.csv");
            parser.Parse(example);
			CSV csv = parser.Flush();
			Assert.AreEqual(1, csv.Count);
            Assert.AreEqual(1, csv.Header.Length);
            Assert.AreEqual("a, b", csv[0][0]);
        }

        [TestMethod]
        public void RowsTest()
        {
            Assert.AreEqual(2, m_Example.Count);
            CSVRow row;

            row = m_Example[0];
            Assert.AreEqual(4, row.Length);
            Assert.AreEqual("a", row[0]);
            Assert.AreEqual("b", row[1]);
            Assert.AreEqual("1", row[2]);
            Assert.AreEqual("true", row[3]);

            row = m_Example[1];
            Assert.AreEqual(4, row.Length);
            Assert.AreEqual("\"quoted\"", row[0]);
            Assert.AreEqual("2", row[1]);
            Assert.AreEqual("3", row[2]);
            Assert.AreEqual("", row[3]);
        }

        [TestMethod]
        public void ToStringTest()
        {
            CSVParser parser = new CSVParser();
			parser.Parse(m_Example.ToString());
			CSV example = parser.Flush();
            Assert.AreEqual(true, m_Example.Equals(example));
        }
    }
}
