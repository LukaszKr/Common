using System;

namespace ProceduralLevel.Common.SimpleID
{
	public class IDGroup<TID>
		where TID : ID
	{
		private const int BUFFER_SIZE = 8;
		private const int HALF_SIZE = BUFFER_SIZE/2;

		private TID[] m_IDBuffer = new TID[BUFFER_SIZE];
		private int m_IDCount;

		public int Count { get { return m_IDCount; } }

		public void RegisterID(TID id)
		{
			int desiredIndex = 0;
			int length = m_IDBuffer.Length;
			if(m_IDCount+1 == length)
			{
				TID[] newBuffer = new TID[length*2];
				for(int x = 0; x < length; ++x)
				{
					newBuffer[x] = m_IDBuffer[x];
				}
				m_IDBuffer = newBuffer;
				length = newBuffer.Length;
			}

			for(int x = 0; x < length; ++x)
			{
				TID current = m_IDBuffer[x];
				if(current == null || current.Value > id.Value)
				{
					desiredIndex = x;
					break;
				}
				else if(current.Value == id.Value)
				{
					string error = string.Format("Duplicated CommandID Value. Existing: {0}, New: {1}",
						current.ToString(), id.ToString());
					throw new ArgumentException(error);
				}
			}

			for(int x = m_IDCount; x > desiredIndex; --x)
			{
				m_IDBuffer[x] = m_IDBuffer[x-1];
			}
			m_IDBuffer[desiredIndex] = id;
			++m_IDCount;
		}

		public TID Get(uint id)
		{
			TID currentID = null;
			int currentIndex = HALF_SIZE;
			int partSize = HALF_SIZE;
			while(true)
			{
				currentID = m_IDBuffer[currentIndex];
				if(currentID == null)
				{
					currentIndex -= partSize;
				}
				else if(currentID.Value == id)
				{
					return currentID;
				}
				else if(currentID.Value > id)
				{
					currentIndex -= partSize;
				}
				else
				{
					currentIndex += partSize;
				}
				if(partSize == 0)
				{
					return null;
				}
				partSize = partSize >> 1;
			}
		}
	}
}
