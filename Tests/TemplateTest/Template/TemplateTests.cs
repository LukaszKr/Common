using NUnit.Framework;
using Test.Template.Data;

namespace Tests.Template
{
	[TestFixture]
	public class TemplateTests
	{
		private TestData m_Data;

		[SetUp]
		public void Initialize()
		{
			m_Data = new TestData();
		}

		[Test]
		public void HelloWorld()
		{
			TestHelper.AssertTemplate(
				"<b>World</b>",
				"<b>{Hello}</b>",
				m_Data);

			TestHelper.AssertTemplate(
				"<b>World</b>",
				"<b>{this.Hello}</b>",
				m_Data);
		}

		[Test]
		public void NullContext()
		{
			TestHelper.AssertTemplate("NullContext", "NullContext", null);
		}

		[Test]
		public void PrintString()
		{
			TestHelper.AssertTemplate(
				"hello world",
				"{this}",
				"hello world");
		}

		[Test]
		public void PrintNestedObject()
		{
			TestHelper.AssertTemplate(
				"123",
				"{Nested.Val}",
				m_Data);

			TestHelper.AssertTemplate(
				"123",
				"{this.Nested.Val}",
				m_Data);
		}

		[Test]
		public void MethodInvoke()
		{
			TestHelper.AssertTemplate(
				"ExampleMethod",
				"{ExampleMethod()}",
				m_Data);
		}

		[Test]
		public void MethodWithParameterInvoke()
		{
			TestHelper.AssertTemplate(
				"World",
				"{MethodWithParameter(Hello)}",
				m_Data);
		}

		[Test]
		public void PrintArray()
		{
			TestHelper.AssertTemplate(
				"1, 2, 3, ",
				"{this}, ",
				new int[] { 1, 2, 3 });
		}
	}
}
