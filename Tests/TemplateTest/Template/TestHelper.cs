using NUnit.Framework;
using ProceduralLevel.Common.Template;

namespace Test.Template
{
	public static class TestHelper
	{
		public static void AssertTemplate(TemplateManager manager, string expected, string rawTemplate, object data)
		{
			manager.Parse("{#template}"+rawTemplate);
			TextTemplate template = manager.GetTemplate("template");

			Assert.AreEqual(expected, template.Compile(manager, data));

			manager.RemoveTemplate("template");
		}
	}
}
