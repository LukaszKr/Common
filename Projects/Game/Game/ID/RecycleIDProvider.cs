using ProceduralLevel.Serialization;
using System;
using System.Collections.Generic;

namespace ProceduralLevel.Game.ID
{
	public class RecycleIDProvider: BaseIDProvider
	{
		private int m_NextID = 1;
		private Queue<int> m_UnusedIDs = new Queue<int>();
		private HashSet<int> m_UsedIDs = new HashSet<int>();

		public override int GetID()
		{
			if(m_UnusedIDs.Count > 0)
			{
				return m_UnusedIDs.Dequeue();
			}
			else
			{
				while(m_UsedIDs.Contains(m_NextID))
				{
					m_NextID++;
				}
				m_UsedIDs.Add(m_NextID);
				return m_NextID;
			}
		}

		public override void ReleaseID(int ID)
		{
			m_UnusedIDs.Enqueue(ID);
		}

		public override void ReserveID(int ID)
		{
			m_UsedIDs.Add(ID);
		}

		public void DetectUnused()
		{
			int maxID = 0;
			foreach(int usedID in m_UsedIDs)
			{
				maxID = Math.Max(maxID, usedID);
			}
			for(int x = 1; x < maxID; x++)
			{
				if(!m_UsedIDs.Contains(x))
				{
					m_UnusedIDs.Enqueue(x);
				}
			}
		}

		#region Serialization
		private const string KEY_NEXT_ID = "nextID";

		public override void Serialize(AObject serializer)
		{
			serializer.Write(KEY_NEXT_ID, m_NextID);
		}

		public override void Deserialize(AObject serializer)
		{
			m_NextID = serializer.ReadInt(KEY_NEXT_ID);
		}
		#endregion
	}
}
