using System.Collections.Generic;
using System.Text;

namespace ProceduralLevel.Common.Serialization.CSV
{
	public sealed class CSVTable
	{
		public char Separator;
		public readonly List<CSVEntry> Entries = new List<CSVEntry>();

		public CSVTable()
		{
			Separator = CSVTokenizer.SEPARATOR;
		}

		public CSVTable(char separator)
		{
			Separator = separator;
		}

		public void ToString(StringBuilder sb)
		{
			int count = Entries.Count;
			for(int x = 0; x < count; ++x)
			{
				Entries[x].ToString(sb, Separator);
				sb.AppendLine();
			}
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			return sb.ToString();
		}
	}
}
