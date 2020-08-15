namespace Tests.Collision2D
{
	public abstract class ACollisionTest
	{
		private string m_Description = null;

		public abstract bool Passed();

		protected abstract string GetDescription();

		public override string ToString()
		{
			if(m_Description == null)
			{
				m_Description = GetDescription();
			}
			return m_Description;
		}
	}
}
