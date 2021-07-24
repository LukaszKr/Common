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

		public static bool GetIntersection(Line a, Line b, out Point intersection)
		{
			float a1 = a.B.Y-a.A.Y;
			float b1 = a.A.X-a.B.X;
			float c1 = a1*a.A.X+b1*a.A.Y;

			float a2 = b.B.Y-b.A.Y;
			float b2 = b.A.X-b.B.X;
			float c2 = a2*b.A.X+b2*b.A.Y;

			float delta = a1*b2-a2*b1;
			if(delta == 0)
			{
				intersection = new Point();
				return false;
			}

			float x = (b2*c1-b1*c2)/delta;
			float y = (a1*c2-a2*c1)/delta;
			intersection = new Point(x, y);
			return true;
		}
		#endregion
	}
}
