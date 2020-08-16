using ProceduralLevel.Common.Template.Evaluator;
using ProceduralLevel.Common.Tokenize;
using System.Collections.Generic;

namespace ProceduralLevel.Common.Template.Parser
{
	public class TemplateParser: AParser<TemplateTokenizer, TextTemplate>
	{
		private readonly List<AEvaluator> m_Evaluators = new List<AEvaluator>();

		public TemplateParser()
			: base(new TemplateTokenizer())
		{
		}

		protected override void Reset()
		{
			base.Reset();
			m_Evaluators.Clear();
		}

		protected override TextTemplate Parse()
		{
			while(HasTokens())
			{
				ParseTokens();
			}

			int evalCount = m_Evaluators.Count;
			if(evalCount > 0)
			{
				TextTemplate template = new TextTemplate();
				for(int x = 0; x < m_Evaluators.Count; x++)
				{
					AEvaluator evaluator = m_Evaluators[x];
					template.AddEvalautor(evaluator);
				}
				return template;
			}
			return null;
		}

		private void ParseTokens()
		{
			Token token = ConsumeToken();
			switch(token.Value[0])
			{
				case TemplateConst.BRACES_OPEN:
					Token contextToken = PeekToken();
					switch(contextToken.Value[0])
					{
						case TemplateConst.TEMPLATE_NAME:
							break;
						default:
							ParseAccess();
							break;
					}
					break;
				default:
					Push(new StringEvaluator(token.Value));
					return;
			}
		}

		private void ParseAccess()
		{
			while(HasTokens())
			{
				Token token = PeekToken();

				switch(token.Value[0])
				{
					case TemplateConst.BRACES_CLOSE:
						ConsumeToken();
						return;
					case TemplateConst.DOT:
						ConsumeToken();
						ParseAccess();
						ParseDotGetter();
						return;
					case TemplateConst.SEPARATOR:
						ConsumeToken();
						break;
					case TemplateConst.PARENT_CLOSE:
						return;
					case TemplateConst.PARENT_OPEN:
						ConsumeToken();
						ParseMethod();
						break;
					default:
						if(token.IsSeparator)
						{
							throw new TemplateParserException(ETemplateParserError.UnexpectedToken, token);
						}
						ConsumeToken();
						Push(new GetterEvaluator(token.Value));
						break;
				}
			}
		}

		private void ParseDotGetter()
		{
			AEvaluator value = Pop();
			AEvaluator key = Pop();
			Push(new DotGetterEvaluator(key, value));
		}

		private void ParseMethod()
		{
			AEvaluator methodName = Pop();
			if(methodName.EvalType != EEvaluatorType.Getter)
			{
				throw new TemplateParserException(ETemplateParserError.Method_IncorrectName, PeekToken());
			}
			MethodEvaluator method = new MethodEvaluator(methodName.ToString());
			int count = m_Evaluators.Count;

			while(HasTokens() && PeekToken().Value[0] != TemplateConst.PARENT_CLOSE)
			{
				ParseAccess();
			}

			ConsumeToken();

			for(int x = count; x < m_Evaluators.Count; x++)
			{
				method.AddArgument(m_Evaluators[x]);
			}

			while(m_Evaluators.Count > count)
			{
				Pop();
			}
			Push(method);
		}

		private void Push(AEvaluator evaluator)
		{
			m_Evaluators.Add(evaluator);
		}

		private AEvaluator Pop()
		{
			int last = m_Evaluators.Count-1;
			AEvaluator evaluator = m_Evaluators[last];
			m_Evaluators.RemoveAt(last);
			return evaluator;
		}

		public static bool IsBasicLetter(char c)
		{
			return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
		}
	}
}
