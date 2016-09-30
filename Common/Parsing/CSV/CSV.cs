using System;
using System.Collections.Generic;

namespace ProceduralLevel.Common.Parsing
{
    public class CSV: IEquatable<CSV>
    {
        public string Separator { get; private set; }

        public CSVRow Header { get; private set; }

        private List<CSVRow> m_Rows;
        public int Count { get { return m_Rows.Count; } }
        public CSVRow this[int x]
        {
            get { return m_Rows[x]; }
        }

        public CSV(string separator)
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
            string result = Header.ToString(Separator);
            for(int x = 0; x < Count; x++)
            {
                result += "\r\n"+m_Rows[x].ToString(Separator);
            }
            return result;
        }
    }
}
