using System;

namespace ProceduralLevel.Common.Collision2D
{
	public static partial class Detection
	{
		#region Point to...
		public static float Distance(Point a, Point b)
		{
			return (float)Math.Sqrt(DistanceSqr(a, b));
		}

		public static float DistanceSqr(Point a, Point b)
		{
			float dx = (a.X-b.X);
			float dy = (a.Y-b.Y);
			return dx*dx+dy*dy;
		}

		public static float Distance(Point p, Circle c)
		{
			return (float)Math.Sqrt(DistanceSqr(p, c));
		}

		public static float DistanceSqr(Point p, Circle c)
		{
			return DistanceSqr(p, c.Center, c.Radius);
		}

		public static float Distance(Point p, Line l, bool segment)
		{
			return (float)Math.Sqrt(DistanceSqr(p, l, segment));
		}

		public static float DistanceSqr(Point p, Line l, bool segment)
		{
			float dx = (l.B.X-l.A.X);
			float dy = (l.B.Y-l.A.Y);

			if(segment)
			{
				if(dx == 0 && dy == 0)
				{
					return l.A.DistanceSqr(p);
				}
				float pdx = p.X-l.A.X;
				float pdy = p.Y-l.A.Y;
				float ratio = (pdx*dx+pdy*dy)/(dx*dx+dy*dy);
				if(ratio < 0)
				{
					return l.A.DistanceSqr(p);
				}
				else if(ratio > 1)
				{
					return l.B.DistanceSqr(p);
				}
				else
				{
					return DistanceSqr(p, l, false);
				}
			}
			else
			{
				float lineLength = dx*dx+dy*dy;
				float ldx = (l.A.Y-p.Y)*dx;
				float ldy = (l.A.X-p.X)*dy;
				float dist = (ldx-ldy)*(ldx-ldy)/lineLength;
				return (dist < 0 ? -dist : dist); //abs would require double->float casting
			}
		}
		#endregion

		#region Circle to...
		public static float Distance(Circle a, Circle b)
		{
			return (float)Math.Sqrt(DistanceSqr(a, b));
		}

		public static float DistanceSqr(Circle a, Circle b)
		{
			return DistanceSqr(a.Center, b.Center, a.Radius+b.Radius);
		}

		public static float Distance(Circle c, Line l, bool segment)
		{
			float distance = Distance(c.Center, l, segment)-c.Radius;
			if(distance < 0)
			{
				return 0;
			}
			return distance;
			//return (float)Math.Sqrt(DistanceSqr(c, l, segment));
		}

		//public static float DistanceSqr(Circle c, Line l, bool segment)
		//{
		//	//TODO;
		//}
		#endregion

		#region Ellipse to...

		#endregion

		#region Line to...

		#endregion

		#region BoundBox to...

		#endregion

		#region Common
		private static float DistanceSqr(Point a, Point b, float gap)
		{
			float dx = AddGap(a.X-b.X, gap);
			float dy = AddGap(a.Y-b.Y, gap);
			float dist = dx*dx+dy*dy;
			if(dist <= 0)
			{
				return 0;
			}
			return dist;
		}

		private static float AddGap(float v, float gap)
		{
			v = (v < 0 ? -v : v);
			return (v > gap ? v-gap : 0);
		}
		#endregion
	}
}
