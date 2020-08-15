using ProceduralLevel.Common.Collision2D;

namespace Tests.Collision2D
{
	public class PointToCircleDistanceTest: ADistanceTest
	{
		private readonly Point m_P;
		private readonly Circle m_C;
		private readonly float m_Calculated;

		public PointToCircleDistanceTest(Point p, Circle c, float expected) : base(expected)
		{
			m_P = p;
			m_C = c;
			m_Calculated = m_P.Distance(m_C);
		}

		protected override float GetDistance()
		{
			return m_Calculated;
		}
	}
}
