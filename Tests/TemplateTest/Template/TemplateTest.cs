using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralLevel.Common.Template;

namespace Test.Template
{
	public class TestData
	{ 
		public string Hello = "World";
		public NestedClass Nested = new NestedClass();
		public string[] Arr = new string[] { "a", "b" };
	}

	public class NestedClass
	{
		public int val = 123;
	}


	[TestClass]
	public class TemplateTest
	{
		private TemplateManager m_Manager;
		private TestData m_Data;

		[TestInitialize]
		public void Initialize()
		{
			m_Manager = new TemplateManager();
			m_Data = new TestData();
		}

		[TestMethod]
		public void HelloWorld()
		{
			TestHelper.AssertTemplate(m_Manager,
				"<b>World</b>",
				"<b>{Hello}</b>",
				m_Data);
		}

		[TestMethod]
		public void ShouldPrintOutTheData()
		{
			TestHelper.AssertTemplate(m_Manager,
				"hello world",
				"{this}",
				"hello world");
		}

		[TestMethod]
		public void PrintNestedObject()
		{
			TestHelper.AssertTemplate(m_Manager,
				"123",
				"{Nested.val}",
				m_Data);
		}

		[TestMethod]
		public void PrintArrayElement()
		{
			TestHelper.AssertTemplate(m_Manager,
				"b",
				"{Arr[1]}",
				m_Data);
		}
	}
}
