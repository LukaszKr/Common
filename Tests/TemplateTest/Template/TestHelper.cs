using NUnit.Framework;
using ProceduralLevel.Common.Template;
using ProceduralLevel.Common.Template.Parser;

namespace Tests.Template
{
	public static class TestHelper
	{
		public static void AssertTemplate(string expected, string rawTemplate, object context)
		{
			TemplateParser parser = new TemplateParser();
			TextTemplate template = parser.Parse(rawTemplate).Flush();

			Assert.AreEqual(expected, template.Compile(context));
		}
	}
}
