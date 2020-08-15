using NUnit.Framework;
using ProceduralLevel.Common.Template;
using Test.Template.Data;

namespace Tests.Template
{
	[TestFixture]
	public class TemplateTest
	{
		private TemplateManager m_Manager;
		private TestData m_Data;
		private GlobalContext m_GlobalContext;

		[SetUp]
		public void Initialize()
		{
			m_Manager = new TemplateManager();
			m_Data = new TestData();
			m_GlobalContext = new GlobalContext(m_Manager);
		}

		[Test]
		public void HelloWorld()
		{
			TestHelper.AssertTemplate(m_Manager,
				"<b>World</b>",
				"<b>{Hello}</b>",
				m_Data, m_GlobalContext);

			TestHelper.AssertTemplate(m_Manager,
				"<b>World</b>",
				"<b>{this.Hello}</b>",
				m_Data, m_GlobalContext);
		}

		[Test]
		public void ShouldPrintOutTheData()
		{
			TestHelper.AssertTemplate(m_Manager,
				"hello world",
				"{this}",
				"hello world", m_GlobalContext);
		}

		[Test]
		public void PrintNestedObject()
		{
			TestHelper.AssertTemplate(m_Manager,
				"123",
				"{Nested.Val}",
				m_Data, m_GlobalContext);

			TestHelper.AssertTemplate(m_Manager,
				"123",
				"{this.Nested.Val}",
				m_Data, m_GlobalContext);
		}

		[Test]
		public void PrintArrayElement()
		{
			TestHelper.AssertTemplate(m_Manager,
				"b",
				"{Arr[1]}",
				m_Data, m_GlobalContext);
		}

		[Test]
		public void PrintArrayElementField()
		{
			TestHelper.AssertTemplate(m_Manager,
				"123",
				"{NestedClassArr[0].Val}",
				m_Data, m_GlobalContext);
		}

		[Test]
		public void MethodInvoke()
		{
			TestHelper.AssertTemplate(m_Manager,
				"ExampleMethod",
				"{ExampleMethod()}",
				m_Data, m_GlobalContext);
		}

		[Test]
		public void NestedMethodInvoke()
		{
			TestHelper.AssertTemplate(m_Manager,
				"NestedMethod",
				"{NestedClassArr[0].NestedMethod()}",
				m_Data, m_GlobalContext);
		}

		[Test]
		public void MethodWithParameterInvoke()
		{
			TestHelper.AssertTemplate(m_Manager,
				"World",
				"{MethodWithParameter(Hello)}",
				m_Data, m_GlobalContext);
		}

		[Test]
		public void MethodWithStringParameterInvoke()
		{
			TestHelper.AssertTemplate(m_Manager,
				"World",
				"{MethodWithParameter(\"World\")}",
				m_Data, m_GlobalContext);
		}

		[Test]
		public void GlobalContextInclude()
		{
			m_Manager.Parse("{#nested}{Hello}");
			TestHelper.AssertTemplate(m_Manager,
				"World",
				@"{$Include(""nested"", this)}",
				m_Data, m_GlobalContext);
			m_Manager.RemoveTemplate("nested");
		}
	}
}
