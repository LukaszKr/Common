using System.Collections.Generic;

namespace ProceduralLevel.Common.Parsing.Template
{
	public class Parser: AParser<Template[]>
	{
		private List<AEvaluator> m_Stack = new List<AEvaluator>();

		public Parser() : base(new TemplateTokenizer())
		{
		}

		protected override Template[] Parse()
		{
			List<Template> templates = new List<Template>();
			while(HasTokens())
			{
				ParseStringEval();
			}

			Template template = null;
			for(int x = 0; x < m_Stack.Count; x++)
			{
				AEvaluator evaluator = m_Stack[x];
				if(evaluator.Type == EEvaluatorType.Name)
				{
					NameEvaluator nameEval = evaluator as NameEvaluator;
					if(template != null)
					{
						templates.Add(template);
					}
					template = new Template(nameEval.Name);
				}
				else if(template != null)
				{
					template.Add(evaluator);
				}
			}

			if(template != null)
			{
				templates.Add(template);
			}

			return templates.ToArray();
		}

		private void ParseStringEval()
		{
			Token token = ConsumeToken();
			switch(token.Value)
			{
				case Consts.BRACKET_OPEN:
					ParseGetter();
					break;
				default:
					m_Stack.Add(new StringEvaluator(token.Value));
					break;
			}
		}

		private void ParseName()
		{
			string name = "";
			while(HasTokens())
			{
				string tokenValue = ConsumeToken().Value.Trim();
				if(tokenValue.Length == 0)
				{
					continue;
				}

				switch(tokenValue)
				{
					case Consts.BRACKET_CLOSE:
						m_Stack.Add(new NameEvaluator(name));
						return;
					default:
						name += tokenValue;
						break;
				}
			}
		}

		private void ParseGetter()
		{
			bool isString = false;
			string quote = "";

			while(HasTokens())
			{
				string tokenValue = PeekToken().Value;
				string trimmedValue = tokenValue.Trim();
				if(trimmedValue.Length == 0)
				{
					ConsumeToken();
					continue;
				}

				switch(trimmedValue)
				{
					case Consts.TEMPLATE_MARKER:
						ConsumeToken();
						ParseName();
						return;
					case Consts.BRACKET_CLOSE:
						ConsumeToken();
						return;
					case Consts.SQUARE_CLOSE:
						{
							ConsumeToken();
							AEvaluator value = Pop();
							AEvaluator key = Pop();
							m_Stack.Add(new KeyGetterEvaluator(key, value, false));
						}

						break;
					case Consts.DOT:
						{
							ConsumeToken();
							ParseGetter();
							AEvaluator value = Pop();
							AEvaluator key = Pop();
							m_Stack.Add(new KeyGetterEvaluator(key, value, true));
						}
						return;
					case Consts.SQUARE_OPEN:
						ConsumeToken();
						break; 
					case Consts.PARAM_SEPARATOR:
						ConsumeToken();
						break;
					case Consts.PARENT_CLOSE:
						return;
					case Consts.PARENT_OPEN:
						ConsumeToken();
						ParseFunction();
						break;
					case Consts.SINGLE_QUOTE:
					case Consts.QUOTE:
						ConsumeToken();
						if(!isString || quote == tokenValue)
						{
							quote = tokenValue;
							isString = !isString;
						}
						else if(isString)
						{
							m_Stack.Add(new StringEvaluator(tokenValue));
						}
						break;
					default:
						ConsumeToken();
						if(isString)
						{
							m_Stack.Add(new StringEvaluator(tokenValue));
						}
						else
						{
							char c = tokenValue[0];
							if(c >= '0' && c <= '9' || c == '.')
							{
								m_Stack.Add(new StringEvaluator(tokenValue));
							}
							else
							{
								m_Stack.Add(new GetterEvaluator(trimmedValue));
							}
						}
						break;
				}
			}
		}

		private void ParseFunction()
		{
			FunctionEvaluator func = new FunctionEvaluator(Pop());
			int count = m_Stack.Count;

			while(HasTokens() && PeekToken().Value.Trim() != Consts.PARENT_CLOSE)
			{
				ParseGetter();
			}
			ConsumeToken();

			for(int x = count; x < m_Stack.Count; x++)
			{
				func.addEvaluator(m_Stack[x]);
			}

			while(m_Stack.Count > count)
			{
				Pop();
			}

			m_Stack.Add(func);
		}

		private AEvaluator Pop()
		{
			int index = m_Stack.Count-1;
			AEvaluator evaluator = m_Stack[index];
			m_Stack.RemoveAt(index);
			return evaluator;
		}
	}
}
