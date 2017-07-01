using ProceduralLevel.Tokenize;
using System.Collections.Generic;

namespace ProceduralLevel.Serialization.CSV
{
	public class CSVParser: AParser<CSVObject>
	{
		public CSVParser() : base(new CSVTokenizer())
		{
		}

		protected override CSVObject Parse()
		{
			CSVObject csv = null;
			while(HasTokens())
			{
				CSVEntry entry = ParseEntry();
				if(entry != null)
				{
					if(csv == null)
					{
						csv = new CSVObject(entry.Size);
						csv.Header.Copy(entry);
					}
					else
					{
						csv.Add(entry);
					}
				}
			}

			return csv;
		}

		private CSVEntry ParseEntry()
		{
			List<string> values = new List<string>();
			bool isQuoted = false;
			bool hasQuotedValue = false;
			string value = "";

			while(HasTokens())
			{
				Token token = ConsumeToken();
				switch(token.Value[0])
				{
					case CSVConst.SEPARATOR:
						if(isQuoted)
						{
							value += token.Value;
							hasQuotedValue = true;
						}
						else
						{
							values.Add(CSVConst.UnEscapeString(value));
							value = "";
						}
						break;
					case CSVConst.QUOTATION:
						if(!hasQuotedValue && isQuoted)
						{
							value += token.Value;
							hasQuotedValue = false;
						}
						isQuoted = !isQuoted;
						break;
					case CSVConst.NEW_LINE:
						if(isQuoted)
						{
							value += token.Value;
							hasQuotedValue = true;
						}
						else
						{
							return new CSVEntry(values);
						}
						break;
					default:
						value += token.Value;
						if(isQuoted)
						{
							hasQuotedValue = true;
						}
						break;
				}
			}

			values.Add(CSVConst.UnEscapeString(value));
			return new CSVEntry(values);
		}
	}
}
