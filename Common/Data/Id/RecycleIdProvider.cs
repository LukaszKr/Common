using System.Collections.Generic;

namespace ProceduralLevel.Common.Data
{
	public class RecycleIdProvider: BaseIdProvider
	{
		private int m_NextId = 0;
		private Queue<int> m_UnusedIds = new Queue<int>();

		public override int GetId()
		{
			if(m_UnusedIds.Count > 0)
			{
				return m_UnusedIds.Dequeue();
			}
			return ++m_NextId;
		}

		public override void ReleaseId(int id)
		{
			m_UnusedIds.Enqueue(id);
		}
	}
}
