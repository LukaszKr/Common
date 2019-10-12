namespace ProceduralLevel.Common.Collision2D
{
	public static partial class Detection
	{
		#region Point to...
		public static bool Intersects(Point p, Circle c)
		{
			return DistanceSqr(p, c) == 0;
		}

		public static bool Intersects(Point p, Line l)
		{
			return Orientation(p, l) == EOrientation.On;
		}
		#endregion

		#region Cirlce to...
		public static bool Intersects(Circle a, Circle b)
		{
			return DistanceSqr(a, b) == 0;
		}

		public static bool Intersects(Circle c, Line l)
		{
			return Distance(c, l, true) == 0;	
			//return DistanceSqr(c, l, true) == 0;	
		}
		#endregion

		#region Line to...
		public static bool Intersects(Line a, Line b)
		{
			EOrientation baa = Orientation(b.A, a);
			EOrientation bba = Orientation(b.B, a);
			EOrientation aab = Orientation(a.A, b);
			EOrientation abb = Orientation(a.B, b);
			return (baa != bba && aab != abb) || (baa == EOrientation.On && aab == EOrientation.On);
		}
		#endregion
	}
}
