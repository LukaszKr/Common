using ProceduralLevel.Common.Collision2D;

namespace Tests.Collision2D
{
	public class PointToPointDistanceTest: ADistanceTest
	{
		private readonly Point m_A;
		private readonly Point m_B;
		private readonly float m_Calculated;

		public PointToPointDistanceTest(Point a, Point b, float expected) : base(expected)
		{
			m_A = a;
			m_B = b;
			m_Calculated = a.Distance(b);
		}

		protected override float GetDistance()
		{
			return m_Calculated;
		}
	}
}
