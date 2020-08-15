using ProceduralLevel.Common.Template.Evaluator;
using ProceduralLevel.Common.Tokenize;
using System.Collections.Generic;

namespace ProceduralLevel.Common.Template.Parser
{
	public class TemplateParser: AParser<TemplateTokenizer, List<TextTemplate>>
	{
		private readonly List<AEvaluator> m_Evaluators = new List<AEvaluator>();

		public TemplateParser() : base(new TemplateTokenizer())
		{
		}

		protected override void Reset()
		{
			base.Reset();
			m_Evaluators.Clear();
		}

		protected override List<TextTemplate> Parse()
		{
			List<TextTemplate> templates = new List<TextTemplate>();

			while(HasTokens())
			{
				ParseTokens();
			}

			TextTemplate template = null;
			for(int x = 0; x < m_Evaluators.Count; x++)
			{
				AEvaluator evaluator = m_Evaluators[x];
				if(evaluator.EvalType == EEvaluatorType.Name)
				{
					TemplateNameEvaluator nameEval = evaluator as TemplateNameEvaluator;
					if(template != null)
					{
						templates.Add(template);
					}
					template = new TextTemplate(nameEval.Name);
				}
				else
				{
					template.AddEvalautor(evaluator);
				}
			}

			if(template != null)
			{
				templates.Add(template);
			}

			return templates;
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
							ParseTemplateName();
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

		private void ParseTemplateName()
		{
			ConsumeToken();
			Token token = ConsumeToken();
			char firstChar = token.Value[0];
			if(!IsBasicLetter(firstChar))
			{
				throw new TemplateParserException(ETemplateParserError.TemplateName_IllegalCharacter, token);
			}
			TemplateNameEvaluator evaluator = new TemplateNameEvaluator(token.Value);
			Push(evaluator);

			token = ConsumeToken();
			if(!token.IsSeparator || token.Value[0] != TemplateConst.BRACES_CLOSE)
			{
				throw new TemplateParserException(ETemplateParserError.TemplateName_IllegalFormat, token);
			}
		}

		private void ParseAccess()
		{
			bool isString = false;
			bool globalContext = false;

			while(HasTokens())
			{
				Token token = PeekToken();
				string trimmedValue = token.Value.Trim();
				if(trimmedValue.Length < 1)
				{
					ConsumeToken();
					continue;
				}

				switch(token.Value[0])
				{
					case TemplateConst.GLOBAL:
						ConsumeToken();
						globalContext = true;
						break;
					case TemplateConst.BRACES_CLOSE:
						ConsumeToken();
						return;
					case TemplateConst.SQUARE_CLOSE:
						ConsumeToken();
						ParseArrayGetter();
						break;
					case TemplateConst.SQUARE_OPEN:
						ConsumeToken();
						break;
					case TemplateConst.DOT:
						ConsumeToken();
						ParseAccess();
						ParseKeyGetter();
						return;
					case TemplateConst.SEPARATOR:
						ConsumeToken();
						break;
					case TemplateConst.PARENT_CLOSE:
						return;
					case TemplateConst.PARENT_OPEN:
						ConsumeToken();
						ParseMethod(globalContext);
						break;
					case TemplateConst.QUOTE:
						ConsumeToken();
						isString = !isString;
						break;
					default:
						if(token.IsSeparator)
						{
							throw new TemplateParserException(ETemplateParserError.UnexpectedToken, token);
						}
						ConsumeToken();
						if(isString)
						{
							Push(new StringEvaluator(token.Value));
						}
						else
						{
							char c = trimmedValue[0];
							if(char.IsNumber(c) || c == '.')
							{
								Push(new StringEvaluator(trimmedValue));
							}
							else
							{
								Push(new GetterEvaluator(token.Value, globalContext));
							}
						}
						break;
				}
			}
		}

		private void ParseArrayGetter()
		{
			AEvaluator value = Pop();
			AEvaluator key = Pop();
			Push(new ArrayGetterEvaluator(key, value));
		}

		private void ParseKeyGetter()
		{
			AEvaluator value = Pop();
			AEvaluator key = Pop();
			Push(new KeyGetterEvaluator(key, value));
		}

		private void ParseMethod(bool globalContext)
		{
			AEvaluator methodName = Pop();
			if(methodName.EvalType != EEvaluatorType.Getter)
			{
				throw new TemplateParserException(ETemplateParserError.Method_IncorrectName, PeekToken());
			}
			MethodEvaluator method = new MethodEvaluator(methodName.ToString(), globalContext);
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
