using System;

namespace ProceduralLevel.Common.Template.Parser
{
	public class TemplateEvaluationException: Exception
	{
		public readonly ETemplateEvaluationError ErrorCode;

		public TemplateEvaluationException(ETemplateEvaluationError errorCode)
		{
			ErrorCode = errorCode;
		}

		public override string ToString()
		{
			return $"[{ErrorCode}]";
		}
	}
}
