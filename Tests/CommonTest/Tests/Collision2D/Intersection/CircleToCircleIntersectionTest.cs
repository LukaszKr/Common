using ProceduralLevel.Common.Collision2D;

namespace Tests.Collision2D
{
	public class CircleToCircleIntersectionTest: AIntersectionTest
	{
		private readonly Circle m_A;
		private readonly Circle m_B;
		private readonly bool m_Calculated;

		public CircleToCircleIntersectionTest(Circle a, Circle b, bool expected) : base(expected)
		{
			m_A = a;
			m_B = b;
			m_Calculated = m_A.Intersects(m_B);
		}

		protected override bool Intersects()
		{
			return m_Calculated;
		}
	}
}
