namespace ProceduralLevel.Common.Collision2D
{
	public struct Line
	{
		public readonly Point A;
		public readonly Point B;

		public Line(float aX, float aY, float bX, float bY)
		{
			A = new Point(aX, aY);
			B = new Point(bX, bY);
		}

		public Line(Point a, Point b)
		{
			A = a;
			B = b;
		}

		public float Length()
		{
			return A.Distance(B);
		}

		public float LengthSqr()
		{
			return A.DistanceSqr(B);
		}

		#region Distance
		public float Distance(Point p, bool segment)
		{
			return Detection.Distance(p, this, segment);
		}

		public float DistanceSqr(Point p, bool segment)
		{
			return Detection.DistanceSqr(p, this, segment);
		}

		public float Distance(Circle c, bool segment)
		{
			return Detection.Distance(c, this, segment);
		}

		//public float DistanceSqr(Circle c, bool segment)
		//{
		//	return Helper.DistanceSqr(c, this, segment);
		//}
		#endregion

		#region Intersection
		public bool Intersects(Point p)
		{
			return Detection.Intersects(p, this);
		}

		public bool Intersects(Circle c)
		{
			return Detection.Intersects(c, this);
		}

		public bool Intersects(Line l)
		{
			return Detection.Intersects(this, l);
		}
		#endregion

		public override string ToString()
		{
			return string.Format("[A: {0}, B: {1}]", A.ToString(), B.ToString());
		}
	}
}
