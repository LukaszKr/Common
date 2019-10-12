﻿using ProceduralLevel.Common.Collision2D;

namespace ProceduralLevel.Common.Tests.Collision2D
{
	public class CircleToCircleDistanceTest: ADistanceTest
	{
		private readonly Circle m_A;
		private readonly Circle m_B;
		private readonly float m_Calculated;

		public CircleToCircleDistanceTest(Circle a, Circle b, float expected) : base(expected)
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
