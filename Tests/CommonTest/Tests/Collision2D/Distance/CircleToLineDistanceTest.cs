using ProceduralLevel.Common.Collision2D;

namespace Tests.Collision2D
{
	public class CircleToLineDistanceTest : ADistanceTest
	{
		private readonly Circle m_C;
		private readonly Line m_L;
		private readonly bool m_Segment;
		private readonly float m_Calculated;

		public CircleToLineDistanceTest(Circle c, Line l, bool segment, float expected) : base(expected)
		{
			m_C = c;
			m_L = l;
			m_Segment = segment;
			m_Calculated = m_C.Distance(m_L, m_Segment);
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
