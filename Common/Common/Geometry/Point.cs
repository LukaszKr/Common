using System;

namespace Common.Geometry
{
	public class Point
    {
		public float X { get; private set; }
		public float Y { get; private set; }

		public Point(float x, float y)
		{
			X = x;
			Y = y;
		}

		public Point(Point point)
		{
			Copy(point);
		}

		public void Copy(Point point)
		{
			X = point.X;
			Y = point.Y;
		}

		public double Distance(Point point)
		{
			float distanceX = point.X-X;
			float distanceY = point.Y-Y;
			distanceX = distanceX*distanceX;
			distanceY = distanceY*distanceY;
			return distanceX+distanceY;
		}

		public double DistanceSqrt(Point point)
		{
			return Math.Sqrt(Distance(point));
		}
	}
}
