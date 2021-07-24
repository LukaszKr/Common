using System.Collections.Generic;
using ProceduralLevel.Common.Tokenize;

namespace ProceduralLevel.Common.Serialization.CSV
{
	public sealed class CSVParser : AParser<CSVTokenizer, CSVTable>
	{
		public CSVParser() : base(new CSVTokenizer())
		{
		}

		protected override CSVTable Parse()
		{
			CSVTable table = new CSVTable(m_Tokenizer.LastDetectedSeparator);
			while(HasTokens())
			{
				CSVEntry entry = ParseEntry();
				if(entry != null)
				{
					table.Entries.Add(entry);
				}
			}
			return table;
		}

		private CSVEntry ParseEntry()
		{
			List<string> values = new List<string>();
			string current = string.Empty;
			bool hasValue = false;
			while(HasTokens())
			{
				Token token = ConsumeToken();
				if(token.IsSeparator)
				{
					switch(token.Value[0])
					{
						case CSVTokenizer.TERMINATOR:
							if(hasValue)
							{
								values.Add(current);
							}
							return new CSVEntry(values);
						case CSVTokenizer.ALT_SEPARATOR:
						case CSVTokenizer.SEPARATOR:
							values.Add(current);
							current = string.Empty;
							hasValue = false;
							break;
					}
				}
				else
				{
					hasValue = true;
					current += token.Value;
				}
			}

			if(hasValue)
			{
				values.Add(current);
			}

			if(values.Count > 0)
			{
				return new CSVEntry(values);
			}
			return null;
		}
	}
}
