using ProceduralLevel.Common.Ext;
using System.Collections.Generic;

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

		public override string ToString()
		{
			return Values.JoinToString(CSVTokenizer.SEPARATOR.ToString());
		}
	}
}
