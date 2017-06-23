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
            if(Header == null)
            {
                Header = row;
            }
            else
            {
                if(row.Length != Header.Length)
                {
                    row.Resize(Header.Length);
                }
                m_Rows.Add(row);
            }
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
