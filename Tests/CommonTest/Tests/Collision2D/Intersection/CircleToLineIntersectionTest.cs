using ProceduralLevel.Common.Collision2D;

namespace Tests.Collision2D
{
	public class CircleToLineIntersectionTest: AIntersectionTest
	{
		private readonly Circle m_C;
		private readonly Line m_L;
		private readonly bool m_Calculated;

		public CircleToLineIntersectionTest(Circle c, Line l, bool expected) : base(expected)
		{
			m_C = c;
			m_L = l;
			m_Calculated = c.Intersects(l);
		}

		protected override bool Intersects()
		{
			return m_Calculated;
		}
	}
}
