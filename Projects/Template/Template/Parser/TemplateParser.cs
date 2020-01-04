using ProceduralLevel.Common.Template.Evaluator;
using ProceduralLevel.Common.Tokenize;
using System.Collections.Generic;

namespace ProceduralLevel.Common.Template.Parser
{
	public class TemplateParser: AParser<TemplateTokenizer, List<TextTemplate>>
	{
		private List<AEvaluator> m_Evaluators = new List<AEvaluator>();

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
					NameEvaluator nameEval = evaluator as NameEvaluator;
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
					ParseTemplate();
					break;
				default:
					Push(new StringEvaluator(token.Value));
					return;
			}
		}

		private void ParseTemplate()
		{
			bool isString = false;
			bool isSpecial = false;
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
					case TemplateConst.SPECIAL:
						ConsumeToken();
						isSpecial = true;
						break;
					case TemplateConst.BRACES_CLOSE:
						ConsumeToken();
						return;
					case TemplateConst.SQUARE_CLOSE:
						{
							ConsumeToken();
							ParseKeyGetter(false);
						}
						break;
					case TemplateConst.SQUARE_OPEN:
						ConsumeToken();
						break;
					case TemplateConst.DOT:
						ConsumeToken();
						ParseTemplate();
						ParseKeyGetter(true);
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
					case TemplateConst.QUOTE:
						ConsumeToken();
						if(!isString)
						{
							isString = !isString;
						}
						else
						{
							Push(new StringEvaluator(token.Value));
						}
						break;
					default:
						if(token.IsSeparator)
						{
							throw new TemplateParserException(ETemplateParserError.UnexpectedToken, token);
						}
						if(isString)
						{
							ParseString(isSpecial);
						}
						else
						{
							char c = token.Value[0];
							if(char.IsNumber(c) || c == '.' || isSpecial)
							{
								ParseString(isSpecial);
							}
							else
							{
								ConsumeToken();
								Push(new GetterEvaluator(token.Value));
							}
						}
						break;
				}
			}
		}

		private void ParseKeyGetter(bool dot)
		{
			AEvaluator value = Pop();
			AEvaluator key = Pop();
			Push(new KeyGetterEvaluator(key, value, dot));
		}

		private void ParseMethod()
		{
			MethodEvaluator method = new MethodEvaluator(Pop());
			int count = m_Evaluators.Count;

			while(HasTokens() && PeekToken().Value[0] != TemplateConst.PARENT_CLOSE)
			{
				ParseTemplate();
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

		private void ParseString(bool isSpecial)
		{
			Token token = ConsumeToken();
			if(isSpecial)
			{
				Push(new NameEvaluator(token.Value));
			}
			else
			{
				Push(new StringEvaluator(token.Value));
			}
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
	}
}
