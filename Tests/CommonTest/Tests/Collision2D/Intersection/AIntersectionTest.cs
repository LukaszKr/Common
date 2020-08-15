namespace Tests.Collision2D
{
	public abstract class AIntersectionTest: ACollisionTest
	{
		protected readonly bool m_Expected;

		public AIntersectionTest(bool expected)
		{
			m_Expected = expected;
		}

		public override bool Passed()
		{
			return m_Expected == Intersects();
		}

		protected abstract bool Intersects();

		protected override string GetDescription()
		{
			return string.Format("{0} == {1}", m_Expected, Intersects());
		}
	}
}
