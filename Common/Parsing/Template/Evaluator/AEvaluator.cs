using System.Collections.Generic;

namespace ProceduralLevel.Common.Parsing.Template
{
	public abstract class AEvaluator
    {
		public readonly EEvaluatorType Type;

		public AEvaluator(EEvaluatorType type)
		{
			Type = type;
		}

		public abstract object Evaluate(object data, Dictionary<string, object> scope);
    }
}
