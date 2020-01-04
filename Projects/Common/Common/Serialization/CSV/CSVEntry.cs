using System.Collections.Generic;
using System.Text;

namespace ProceduralLevel.Common.Serialization.CSV
{
	public sealed class CSVEntry
	{
		public readonly string[] Values;

		public CSVEntry(int length)
		{
			Values = new string[length];
		}

		public CSVEntry(params string[] values)
		{
			int length = values.Length;
			Values = new string[length];
			for(int x = 0; x < length; ++x)
			{
				Values[x] = values[x];
			}
		}

		public CSVEntry(List<string> values)
		{
			int length = values.Count;
			Values = new string[length];
			for(int x = 0; x < length; ++x)
			{
				Values[x] = values[x];
			}
		}

		public string ToString(char separator)
		{
			StringBuilder sb = new StringBuilder();
			ToString(sb, separator);
			return sb.ToString();
		}

		public void ToString(StringBuilder sb, char separator)
		{
			int length = Values.Length;
			for(int x = 0; x < length; ++x)
			{
				if(x > 0)
				{
					sb.Append(separator);
				}
				bool putInQuotes = false;
				string value = Values[x];
				if(!string.IsNullOrEmpty(value))
				{
					int strLength = value.Length;
					for(int y = 0; y < strLength; ++y)
					{
						if(value[y] == separator)
						{
							putInQuotes = true;
							break;
						}
					}
				}
				if(putInQuotes)
				{
					sb.Append(CSVTokenizer.QUOTE);
					sb.Append(value);
					sb.Append(CSVTokenizer.QUOTE);
				}
				else
				{
					sb.Append(value);
				}
			}
		}
	}
}
