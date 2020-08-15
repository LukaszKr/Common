using ProceduralLevel.Common.Collision2D;

namespace Tests.Collision2D
{
	public class LineToLineIntersectionTest: AIntersectionTest
	{
		private readonly Line m_A;
		private readonly Line m_B;
		private bool m_Calculated;

		public LineToLineIntersectionTest(Line a, Line b, bool expected) : base(expected)
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
