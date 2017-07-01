using System;
using System.Collections.Generic;
using System.Text;

namespace ProceduralLevel.Serialization.CSV
{
	public class CSVObject
	{
		private List<CSVEntry> m_Data;

		public CSVEntry this[int index]
		{
			get { return m_Data[index]; }
		}

		public CSVEntry Header { get; private set; }
		public int Width { get { return Header.Size; } }
		public int Count { get { return m_Data.Count; } }

		public CSVObject(int width = 0)
		{
			m_Data = new List<CSVEntry>();
			Header = new CSVEntry(width);
		}

		public void Add(CSVEntry entry)
		{
			if(entry.Size != Width)
			{
				throw new ArgumentOutOfRangeException();
			}
			m_Data.Add(entry);
		}

		public void Insert(int index, CSVEntry entry)
		{
			if(entry.Size != Width)
			{
				throw new ArgumentOutOfRangeException();
			}
			m_Data.Insert(index, entry);
		}

		public int IndexOf(CSVEntry entry)
		{
			return m_Data.IndexOf(entry);
		}

		public int IndexOf(int column, string value)
		{
			for(int x = 0; x < m_Data.Count; x++)
			{
				CSVEntry entry = m_Data[x];
				if(entry[column] == value)
				{
					return x;
				}
			}
			return -1;
		}

		public CSVEntry Find(int column, string value)
		{
			int index = IndexOf(column, value);
			if(index == -1)
			{
				return null;
			}
			return m_Data[index];
		}

		public bool Remove(CSVEntry entry)
		{
			return m_Data.Remove(entry);
		}

		public void RemoveAt(int index)
		{
			m_Data.RemoveAt(index);
		}

		#region Columns
		public void Resize(int newSize)
		{
			Header.Resize(newSize);
			for(int x = 0; x < m_Data.Count; x++)
			{
				CSVEntry entry = m_Data[x];
				entry.Resize(newSize);
			}
		}

		public void AddColumn(string name)
		{
			for(int x = 0; x < m_Data.Count; x++)
			{
				CSVEntry entry = m_Data[x];
				entry.Resize(Width);
			}
			Header[Width-1] = name;
		}

		public void AddColumns(params string[] names)
		{
			int oldWidth = Width;
			for(int x = 0; x < m_Data.Count; x++)
			{
				CSVEntry entry = m_Data[x];
				entry.Resize(Width);
			}
			for(int x = 0; x < names.Length; x++)
			{
				Header[x+oldWidth] = names[x];
			}
		}

		public void RemoveColumn(int index)
		{
			for(int x = 0; x < m_Data.Count; x++)
			{
				CSVEntry entry = m_Data[x];
				entry.RemoveColumn(index);
			}
		}

		public void RemoveColumns(params int[] indexes)
		{
			//TODO: optimize it to do it as a single operation
			for(int x = 0; x < indexes.Length; x++)
			{
				RemoveColumn(indexes[x]);
			}
		}

		public void InsertColumn(int index, string name, bool avoidDuplicates = true)
		{
			if(avoidDuplicates && Count > 0 && Header.IndexOf(name) >= 0)
			{
				return;
			}
			for(int x = 0; x < m_Data.Count; x++)
			{
				CSVEntry entry = m_Data[x];
				entry.Insert(index, (x == 0? name: string.Empty));
			}
		}

		#endregion

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			ToString(sb);
			return sb.ToString();
		}

		public void ToString(StringBuilder sb)
		{
			Header.ToString(sb);
			for(int x = 0; x < m_Data.Count; x++)
			{
				sb.Append(CSVConst.NEW_LINE);
				CSVEntry entry = m_Data[x];
				entry.ToString(sb);
			}
		}
	}
}
