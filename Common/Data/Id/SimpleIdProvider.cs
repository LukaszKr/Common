namespace ProceduralLevel.Common.Data
{
	public class SimpleIDProvider: BaseIDProvider
	{
		private int m_NextID;

		public override int GetID()
		{
			return ++m_NextID;
		}
	}
}
