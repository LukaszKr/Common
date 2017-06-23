using System;
using System.Collections.Generic;
using System.Text;

namespace ProceduralLevel.Common.Parsing
{
    public class CSV: IEquatable<CSV>
    {
        public readonly char Separator;

        public CSVRow Header { get; private set; }

        private List<CSVRow> m_Rows;
        public int Count { get { return m_Rows.Count; } }
        public CSVRow this[int x]
        {
            get { return m_Rows[x]; }
        }

        public CSV(char separator = CSVConst.COLUMN_SEPARATOR)
        {
            Separator = separator;
            m_Rows = new List<CSVRow>();
			Header = new CSVRow(0);
        }

		public int FindHeader(string name, StringComparison comparision = StringComparison.OrdinalIgnoreCase)
		{
			for(int x = 0; x < Header.Length; x++)
			{
				string value = Header[x];
				if(name.Equals(value, comparision))
				{
					return x;
				}
			}
			return -1;
		}

		public bool AddHeaders(params string[] names)
		{
			int oldSize = Header.Length;
			int newSize = Header.Length+names.Length;

			Header.Resize(newSize);
			for(int x = oldSize; x < newSize; x++)
			{
				Header[x] = names[x-oldSize];
			}
			for(int x = 0; x < m_Rows.Count; x++)
			{
				m_Rows[x].Resize(newSize);
			}
			return true;
		}

		public int FindRowIndex(int column, string value, StringComparison comparision = StringComparison.OrdinalIgnoreCase)
		{
			for(int x = 0; x < m_Rows.Count; x++)
			{
				CSVRow row = m_Rows[x];
				if(row[column].Equals(value, comparision))
				{
					return x;
				}
			}
			return -1;
		}

		public CSVRow FindRow(int column, string value)
		{
			int index = FindRowIndex(column, value);
			if(index >= 0)
			{
				return m_Rows[index];
			}
			return null;
		}

		public bool Equals(CSV csv)
        {
            if(Count != csv.Count)
            {
                return false;
            }
            if(!Header.Equals(csv.Header))
            {
                return false;
            }
            for(int x = 0; x < Count; x++)
            {
                if(!m_Rows[x].Equals(csv[x]))
                {
                    return false;
                }
            }

            return true;
        }

        public void Add(CSVRow row)
        {
            if(row.Length != Header.Length)
            {
                row.Resize(Header.Length);
            }
			m_Rows.Add(row);
        }

        public override string ToString()
        {
			StringBuilder sb = new StringBuilder();
            Header.ToString(sb, Separator);
            for(int x = 0; x < Count; x++)
            {
				sb.Append(CSVConst.NEW_LINE);
				m_Rows[x].ToString(sb, Separator);
            }
            return sb.ToString();
        }
    }
}
