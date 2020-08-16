using System;
using System.Reflection;

namespace ProceduralLevel.Common.Template.Evaluator
{
	internal abstract class AEvaluator
	{
		public abstract EEvaluatorType EvalType { get; }

		public abstract object Evaluate(object context, object globalContext);

		protected object Get(object context, string name)
		{
			Type type = context.GetType();

			if(type.IsArray)
			{
				Array arr = context as Array;
				return arr.GetValue(int.Parse(name));
			}
			else
			{
				FieldInfo field = type.GetField(name);
				if(field != null)
				{
					return field.GetValue(context);
				}

				PropertyInfo property = type.GetProperty(name);
				if(property != null)
				{
					return property.GetValue(context, null);
				}
			}

			throw new TemplateEvaluationException(ETemplateEvaluationError.Property_NotFound);
		}
	}
}
