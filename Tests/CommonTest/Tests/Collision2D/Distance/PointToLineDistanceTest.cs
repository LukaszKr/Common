using ProceduralLevel.Common.Collision2D;

namespace Tests.Collision2D
{
	public class PointToLineDistanceTest: ADistanceTest
	{
		private readonly Point m_P;
		private readonly Line m_L;
		private readonly bool m_Segment;
		private readonly float m_Calculated;

		public PointToLineDistanceTest(Point p, Line l, bool segment, float expected) : base(expected)
		{
			m_P = p;
			m_L = l;
			m_Segment = segment;
			m_Calculated = m_P.Distance(l, segment);
		}

		protected override float GetDistance()
		{
			return m_Calculated;
		}

		protected override string GetDescription()
		{
			return base.GetDescription()+string.Format(", segment={0}", m_Segment);
		}
	}
}
