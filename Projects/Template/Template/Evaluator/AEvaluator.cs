﻿using System;
using System.Reflection;

namespace ProceduralLevel.Template.Evaluator
{
	public abstract class AEvaluator
	{
		public abstract EEvaluatorType EvalType { get; }

		public abstract object Evaluate(Manager manager, object data);

		protected object Get(object data, string name)
		{
			Type type = data.GetType();

			FieldInfo field = type.GetField(name);
			if(field != null)
			{
				return field.GetValue(data);
			}

			PropertyInfo property = type.GetProperty(name);
			if(property != null)
			{
				return property.GetValue(data);
			}

			return null;
		}
	}
}