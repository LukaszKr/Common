using System;

namespace ProceduralLevel.Common.Tests.Collision2D
{
	public abstract class ADistanceTest: ACollisionTest
	{
		private const float TOLERANCE = 0.0001f;

		protected readonly float m_Expected;

		public ADistanceTest(float expected)
		{
			m_Expected = expected;
		}

		public override bool Passed()
		{
			float delta = Math.Abs(GetDistance()-m_Expected);
			return delta < TOLERANCE;
		}

		protected abstract float GetDistance();

		protected override string GetDescription()
		{
			return string.Format("{0} == {1}", m_Expected, GetDistance());
		}
	}
}
