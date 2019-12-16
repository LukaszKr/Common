using System.Collections.Generic;
using System.Text;

namespace ProceduralLevel.Common.Serialization.CSV
{
	public sealed class CSVTable
	{
		public readonly List<CSVEntry> Entries = new List<CSVEntry>();

		public CSVTable()
		{
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			int count = Entries.Count;
			for(int x = 0; x < count; ++x)
			{
				sb.AppendLine(Entries[x].ToString());
			}
			return sb.ToString();
		}
	}
}
