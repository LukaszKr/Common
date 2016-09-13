namespace ProceduralLevel.Common.Data
{
	public class SimpleIdProvider: BaseIdProvider
	{
		private int m_NextId;

		public override int GetId()
		{
			return ++m_NextId;
		}
	}
}
