using NUnit.Framework;
using ProceduralLevel.Common.Template;

namespace Tests.Template
{
	public static class TestHelper
	{
		public static void AssertTemplate(TemplateManager manager, string expected, string rawTemplate, object context, object globalContext)
		{
			manager.Parse("{#template}"+rawTemplate);
			TextTemplate template = manager.GetTemplate("template");

			Assert.AreEqual(expected, template.Compile(context, globalContext));

			manager.RemoveTemplate("template");
		}
	}
}
