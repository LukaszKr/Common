namespace ProceduralLevel.Common.Helper
{
	public class ChaoticList<T> where T : class 
	{
		private const int SHRINK_LIMIT = 4;
		private const int SHRINK_FACTOR = 2;
		private const int EXPAND_FACTOR = 2;

		private T[] m_Data;
		private int m_Head;
		private int m_InitialSize;

		public T this[int i] 
		{
            get { return m_Data[i]; }
        }

		public int Count 
		{
			get { return m_Head; }
		}

		public int InitialSize 
		{
			get { return m_InitialSize; }
		}

		public int Capacity 
		{
			get { return m_Data.Length; }
		}

		public ChaoticList(int initialSize = 32)
		{
			m_Data = new T[initialSize];
			m_InitialSize = initialSize;
		}

		public void Add(T data)
		{
			m_Data[m_Head] = data;
			m_Head++;
			TryExpand();
		}

		public void Add(params T[] data)
		{
			if(m_Head + data.Length >= m_Data.Length)
			{
				Resize(m_Data.Length * EXPAND_FACTOR);
				for(int x = 0; x < data.Length; x++)
				{
					m_Data[m_Head] = data[x];
					m_Head++;
				}
			}
		}

		public bool Contains(T data)
		{
			for(int x = 0; x < m_Head; x++)
			{
				if(m_Data[x] == data)
				{
					return true;
				}
			}
			return false;
		}

		public bool Remove(T data)
		{
			for(int x = 0; x < m_Head; x++)
			{
				if(m_Data[x] == data)
				{
					return RemoveAt(x);
				}
			}
			return false;
		}

		public bool RemoveAt(int index)
		{
			if(m_Data[index] != null)
			{
				m_Head--;
				m_Data[index] = m_Data[m_Head];
				TryShrink();
				return true;
			}
			return false;
		}

		public void Clear(bool resetSize = true)
		{
			if(resetSize)
			{
				m_Data = new T[m_InitialSize];
			}
			else
			{
				for(int x = 0; x < m_Data.Length; x++)
				{
					m_Data[x] = null;
				}
			}
			m_Head = 0;
		}

		private void TryShrink()
		{
			if(m_Head <= m_Data.Length / SHRINK_LIMIT)
			{
				Resize(m_Data.Length / SHRINK_FACTOR);
			}
		}

		private void TryExpand()
		{
			if(m_Head >= m_Data.Length)
			{
				Resize(m_Data.Length * EXPAND_FACTOR);
			}
		}

		private void Resize(int newSize)
		{
			m_Data = m_Data.Resize(newSize);
		}
	}
}
