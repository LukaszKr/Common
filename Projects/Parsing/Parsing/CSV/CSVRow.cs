using ProceduralLevel.Common.Ext;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProceduralLevel.Parsing
{
    public class CSVRow: IEquatable<CSVRow>
    {
        private string[] m_Data;

        public int Length { get { return m_Data.Length; } }

        public string this[int x]
        {
            get { return m_Data[x]; }
            set { m_Data[x] = value; }
        }

        public CSVRow(int length)
        {
            m_Data = new string[length];
        }

        public CSVRow(List<string> args)
        {
            m_Data = new string[args.Count];
            for(int x = 0; x < args.Count; x++)
            {
                m_Data[x] = args[x];
            }
        }

        public CSVRow(params string[] args)
        {
            m_Data = new string[args.Length];
            for(int x = 0; x < m_Data.Length; x++)
            {
                m_Data[x] = args[x];
            }
        }

        public bool Equals(CSVRow row)
        {
            if(Length != row.Length)
            {
                return false;
            }

            for(int x = 0; x < Length; x++)
            {
                if(!m_Data[x].Equals(row[x]))
                {
                    return false;
                }
            }
            return true;
        }

        public void Resize(int newLength)
        {
			int minLength = Math.Min(newLength, m_Data.Length);
			m_Data = m_Data.Resize(newLength);
            for(int x = minLength; x < m_Data.Length; x++)
            {
                m_Data[x] = "";
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
            for(int x = 0; x < m_Data.Length; x++)
            {
                if(string.IsNullOrEmpty(m_Data[x]))
                {
                    sb.Append(m_Data[x]);
                }
                else
                {
					sb.AppendFormat("\"{0}\"", m_Data[x]);
                }
                if(x < m_Data.Length-1)
                {
					sb.Append(separator);
                }
            }
        }
    }
}
