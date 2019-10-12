using ProceduralLevel.Common.Collision2D;

namespace ProceduralLevel.Common.Tests.Collision2D
{
	public class PointToLineIntersectionTest: AIntersectionTest
	{
		private readonly Point m_P;
		private readonly Line m_L;
		private readonly bool m_Calculated;

		public PointToLineIntersectionTest(Point p, Line l, bool expected) : base(expected)
		{
			m_P = p;
			m_L = l;
			m_Calculated = p.Intersects(l);
		}

		protected override bool Intersects()
		{
			return m_Calculated;
		}
	}
}
