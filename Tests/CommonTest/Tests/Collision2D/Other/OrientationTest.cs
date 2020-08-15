using ProceduralLevel.Common.Collision2D;

namespace Tests.Collision2D
{
	public class OrientationTest: ACollisionTest
	{
		private readonly Line m_Line;
		private readonly Point m_Point;
		private readonly EOrientation m_Expected;
		private readonly EOrientation m_Calculated;

		public OrientationTest(Line line, Point point, EOrientation expected)
		{
			m_Line = line;
			m_Point = point;
			m_Expected = expected;
			m_Calculated = m_Point.Orientation(m_Line);
		}

		public override bool Passed()
		{
			return m_Calculated == m_Expected;
		}

		protected override string GetDescription()
		{
			return string.Format("{0} == {1}", m_Expected.ToString(), m_Calculated.ToString());
		}
	}
}
