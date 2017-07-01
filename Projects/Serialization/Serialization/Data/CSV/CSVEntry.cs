﻿using System.Collections.Generic;
using System.Text;

namespace ProceduralLevel.Serialization.CSV
{
	public class CSVEntry
	{
		private List<string> m_Data;

		public string this[int index]
		{
			get { return m_Data[index]; }
			set { m_Data[index] = value; }
		}

		public int Size { get { return m_Data.Count; } }

		public CSVEntry(int size)
		{
			m_Data = new List<string>(size);
			Resize(size);
		}

		public void RemoveColumn(int index)
		{
			m_Data.RemoveAt(index);
		}

		public int IndexOf(string value)
		{ 
			return m_Data.IndexOf(value);
		}

		public void Insert(int index, string value)
		{
			m_Data.Insert(index, value);
		}

		public void Resize(int newSize)
		{
			for(int x = m_Data.Count; x < newSize; x++)
			{
				m_Data.Add(string.Empty);
			}
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			ToString(sb);
			return sb.ToString();
		}

		public void  ToString(StringBuilder sb)
		{
			for(int x = 0; x < m_Data.Count; x++)
			{
				string value = m_Data[x];
				if(!string.IsNullOrEmpty(value))
				{
					sb.Append(CSVConst.QUOTATION).Append(value).Append(CSVConst.QUOTATION);
				}
				sb.Append(CSVConst.SEPARATOR);
			}
		}
	}
}
