namespace Test.Template.Data
{
	public class TestData
	{
		public string Hello = "World";
		public NestedTestData Nested = new NestedTestData();
		public string[] Arr = new string[] { "a", "b" };
		public NestedTestData[] NestedClassArr = new NestedTestData[] { new NestedTestData() };

		public string ExampleMethod()
		{
			return "ExampleMethod";
		}

		public string MethodWithParameter(string input)
		{
			return input;
		}
	}
}
