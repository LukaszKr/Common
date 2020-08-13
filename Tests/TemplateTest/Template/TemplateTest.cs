namespace Test.Template
{
	public class TestData
	{
		public string Hello = "World";
		public NestedClass Nested = new NestedClass();
		public string[] Arr = new string[] { "a", "b" };
		public NestedClass[] NestedClassArr = new NestedClass[] { new NestedClass() } ;
	}

	public class NestedClass
	{
		public int Val = 123;
	}


	[TestFixture]
	public class TemplateTest
	{
		private TemplateManager m_Manager;
		private TestData m_Data;

		[SetUp]
		public void Initialize()
		{
			m_Manager = new TemplateManager();
			m_Data = new TestData();
		}

		[Test]
		public void HelloWorld()
		{
			TestHelper.AssertTemplate(m_Manager,
				"<b>World</b>",
				"<b>{Hello}</b>",
				m_Data);

			TestHelper.AssertTemplate(m_Manager,
				"<b>World</b>",
				"<b>{this.Hello}</b>",
				m_Data);
		}

		[Test]
		public void ShouldPrintOutTheData()
		{
			TestHelper.AssertTemplate(m_Manager,
				"hello world",
				"{this}",
				"hello world");
		}

		[Test]
		public void PrintNestedObject()
		{
			TestHelper.AssertTemplate(m_Manager,
				"123",
				"{Nested.Val}",
				m_Data);

			TestHelper.AssertTemplate(m_Manager,
				"123",
				"{this.Nested.Val}",
				m_Data);
		}

		[Test]
		public void PrintArrayElement()
		{
			TestHelper.AssertTemplate(m_Manager,
				"b",
				"{Arr[1]}",
				m_Data);
		}

		[Test]
		public void PrintArrayElementField()
		{
			TestHelper.AssertTemplate(m_Manager,
				"123",
				"{NestedClassArr[0].Val}",
				m_Data);
		}
	}
}
