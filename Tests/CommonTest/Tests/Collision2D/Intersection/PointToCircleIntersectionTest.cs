using ProceduralLevel.Common.Collision2D;

namespace ProceduralLevel.Common.Tests.Collision2D
{
	public class PointToCircleIntersectionTest: AIntersectionTest
	{
		private readonly Point m_P;
		private readonly Circle m_C;
		private readonly bool m_Calculated;

		public PointToCircleIntersectionTest(Point p, Circle c, bool expected) : base(expected)
		{
			m_P = p;
			m_C = c;
			m_Calculated = m_P.Intersects(m_C);
		}

		protected override bool Intersects()
		{
			return m_Calculated;
		}
	}
}
