﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralLevel.Common.Parsing;
using System.IO;

namespace CommonUnitTest.Parsing
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
            m_Example = parser.Parse(example);
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
            CSV example = parser.Parse(m_Example.ToString());
            Assert.AreEqual(true, m_Example.Equals(example));
        }
    }
}