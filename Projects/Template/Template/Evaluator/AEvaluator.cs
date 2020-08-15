using System;
using System.Reflection;

namespace ProceduralLevel.Common.Template.Evaluator
{
	public abstract class AEvaluator
	{
		public abstract EEvaluatorType EvalType { get; }

		public abstract object Evaluate(object context, object globalContext);

		protected object Get(object context, string name)
		{
			Type type = context.GetType();

			FieldInfo field = type.GetField(name);
			if(field != null)
			{
				return field.GetValue(context);
			}

			if(type.IsArray)
			{
				Array arr = context as Array;
				return arr.GetValue(int.Parse(name));
			}
			else
			{
				PropertyInfo property = type.GetProperty(name);
				if(property != null)
				{
					return property.GetValue(context, null);
				}
			}

			return null;
		}
	}
}
