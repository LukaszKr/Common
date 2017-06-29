using ProceduralLevel.Serialization;

namespace ProceduralLevel.Game.ID
{
	public class SimpleIDProvider: BaseIDProvider
	{
		private int m_NextID;

		public override int GetID()
		{
			return ++m_NextID;
		}

		public override void ReserveID(int ID)
		{
			if(ID > m_NextID)
			{
				m_NextID = ID;
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
