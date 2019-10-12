namespace ProceduralLevel.Common.Collision2D
{
	public struct Circle
	{
		public readonly Point Center;
		public readonly float Radius;

		public Circle(float x, float y, float radius)
		{
			Center = new Point(x, y);
			Radius = radius;
		}

		public Circle(Point center, float radius)
		{
			Center = center;
			Radius = radius;
		}

		#region Distance
		public float Distance(Point p)
		{
			return Detection.Distance(p, this);
		}

		public float DistanceSqr(Point p)
		{
			return Detection.DistanceSqr(p, this);
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

		//public float DistanceSqr(Line l, bool segment)
		//{
		//	return Helper.DistanceSqr(this, l, segment);
		//}
		#endregion

		#region Intersection
		public bool Intersects(Point p)
		{
			return Detection.Intersects(p, this);
		}

		public bool Intersects(Circle c)
		{
			return Detection.Intersects(this, c);
		}

		public bool Intersects(Line l)
		{
			return Detection.Intersects(this, l);
		}
		#endregion

		public override string ToString()
		{
			return string.Format("[Center: {0}, Radius: {1}]", Center.ToString(), Radius.ToString());
		}
	}
}
