using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralLevel.Serialization.Json;
using System.IO;

namespace Test.Serialization.Json.Parser.Sample
{
	[TestClass]
	public class JsonSampleParserTest
	{
		public const string PATH_PREFIX = "./Sample/JSON/";

		private JsonParser m_Parser;

		[TestInitialize]
		public void Initialize()
		{ 
			m_Parser = new JsonParser();
		}

		[TestMethod]
		public void PowerConsoleSample()
		{
			AssertSample("PowerConsole.json");
		}

		private void AssertSample(string path)
		{
			path = PATH_PREFIX+path;

			string[] lines = File.ReadAllLines(path);
			for(int x = 0; x < lines.Length; x++)
			{
				m_Parser.ParseLine(lines[x]);
			}
			m_Parser.Flush();
		}
	}
}
