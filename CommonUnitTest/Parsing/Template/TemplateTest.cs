using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralLevel.Common.Parsing.Template;
using System.Collections.Generic;

namespace ProceduralLevel.CommonUnitTest.Parsing
{
	public class DataClass
	{
		public NestedDataClass A = new NestedDataClass();
	}

	public class NestedDataClass
	{
		public string B = "hello!";
	}

	[TestClass]
	public class TemplateTest
	{
		private Manager Manager;
		private Dictionary<string, object> m_Data;

		[TestInitialize]
		public void Initialize()
		{
			Manager = new Manager();
			m_Data = new Dictionary<string, object>();
		}

		#region Templte
		[TestMethod]
		public void Template_Compile()
		{
			Manager.Parse("{{#test}}<b>{{text}}</b>");
			Template template = Manager.GetTemplate("test");

			m_Data["text"] = "123";
			string compiled = template.Compile(m_Data, null);
			Assert.AreEqual("<b>123</b>", compiled);
		}

		[TestMethod]
		public void Template_SingleQuote()
		{
			Manager.Parse("{{#singleTest}}{{'hello \"stranger\"!'}}");
			Template template = Manager.GetTemplate("singleTest");

			string compiled = template.Compile(m_Data, null);
			Assert.AreEqual("hello \"stranger\"!", compiled);
		}

		[TestMethod]
		public void Template_ThisAccessor()
		{
			Manager.Parse("{{#data}}{{this}}");
			Template template = Manager.GetTemplate("data");

			string compiled = template.Compile("hello world", null);
			Assert.AreEqual("hello world", compiled);
		}

		[TestMethod]
		public void Template_NestedObjectAccessedWithDot()
		{
			Manager.Parse("{{#nested}} {{A.B}}");
			Template template = Manager.GetTemplate("nested");

			string compiled = template.Compile(new DataClass(), null);
			Assert.AreEqual("hello!", compiled);
		}
		#endregion
	}
}
