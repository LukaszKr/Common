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
			CSVObject csv = new CSVObject();
			while(HasTokens())
			{
				CSVEntry entry = ParseEntry();
				if(entry != null)
				{
					csv.Add(entry);
				}
			}

			return csv;
		}

		private CSVEntry ParseEntry()
		{
			List<string> values = new List<string>();
			bool isQuoted = false;
			string value = "";

			while(HasTokens())
			{
				Token token = PeekToken();
				switch(token.Value[0])
				{
					case CSVConst.SEPARATOR:
						if(isQuoted)
						{
							value += token.Value;
						}
						else
						{
							values.Add(value);
							value = "";
						}
						break;
					case CSVConst.QUOTATION:
						isQuoted = !isQuoted;
						break;
					case CSVConst.NEW_LINE:
						if(isQuoted)
						{
							value += token.Value;
						}
						else
						{
							return new CSVEntry(values);
						}
						break;
					default:
						value += token.Value;
						break;
				}
			}

			values.Add(value);
			return new CSVEntry(values);
		}
	}
}
