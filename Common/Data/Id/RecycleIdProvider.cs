using System.Collections.Generic;

namespace ProceduralLevel.Common.Data
{
	public class RecycleIDProvider: BaseIDProvider
	{
		private int m_NextID = 1;
		private Queue<int> m_UnusedIds = new Queue<int>();
		private HashSet<int> m_UsedIds = new HashSet<int>();

		public override int GetID()
		{
			if(m_UnusedIds.Count > 0)
			{
				return m_UnusedIds.Dequeue();
			}
			else
			{
				while(m_UsedIds.Contains(m_NextID))
				{
					m_NextID++;
				}
				return m_NextID;
			}
		}

		public override void ReleaseID(int ID)
		{
			m_UnusedIds.Enqueue(ID);
		}

		public void ReserveID(int ID)
		{
			m_UsedIds.Add(ID);
		}
	}
}
