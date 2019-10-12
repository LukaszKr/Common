namespace ProceduralLevel.Common.Collision2D
{
	public struct Point
	{
		public readonly float X;
		public readonly float Y;

		public Point(float x, float y)
		{
			X = x;
			Y = y;
		}

		#region Distance
		public float Distance(Point p)
		{
			return Detection.Distance(this, p);
		}

		public float DistanceSqr(Point p)
		{
			return Detection.DistanceSqr(this, p);
		}

		public float Distance(Circle c)
		{
			return Detection.Distance(this, c);
		}

		public float DistanceSqr(Circle c)
		{
			return Detection.DistanceSqr(this, c);
		}

		public float Distance(Line l, bool segment)
		{
			return Detection.Distance(this, l, segment);
		}

		public float DistanceSqr(Line l, bool segment)
		{
			return Detection.DistanceSqr(this, l, segment);
		}
		#endregion

		#region Intersection
		public bool Intersects(Circle c)
		{
			return Detection.Intersects(this, c);
		}

		public bool Intersects(Line l)
		{
			return Detection.Intersects(this, l);
		}
		#endregion

		#region Orientation
		public EOrientation Orientation(Line l)
		{
			return Detection.Orientation(this, l);
		}
		#endregion

		public override string ToString()
		{
			return string.Format("[X: {0}, Y: {1}]", X.ToString(), Y.ToString());
		}
	}
}
