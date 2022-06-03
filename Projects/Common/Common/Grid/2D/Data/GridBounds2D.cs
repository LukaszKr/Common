using System;

namespace ProceduralLevel.Common.Grid
{
	public readonly struct GridBounds2D : IEquatable<GridBounds2D>
	{
		public readonly GridPoint2D Min;
		public readonly GridPoint2D Max;

		public int SizeX { get { return Max.X-Min.X; } }
		public int SizeY { get { return Max.Y-Min.Y; } }

		public static bool operator ==(GridBounds2D left, GridBounds2D right) => left.Equals(right);
		public static bool operator !=(GridBounds2D left, GridBounds2D right) => !left.Equals(right);

		public GridBounds2D(int maxX, int maxY)
		{
			Min = new GridPoint2D(0, 0);
			Max = new GridPoint2D(maxX, maxY);
		}

		public GridBounds2D(int minX, int minY, int maxX, int maxY)
		{
			Min = new GridPoint2D(minX, minY);
			Max = new GridPoint2D(maxX, maxY);
		}

		public GridBounds2D(GridPoint2D min, GridPoint2D max)
		{
			Min = min;
			Max = max;
		}

		public GridBounds2D(GridSize2D size)
		{
			Min = new GridPoint2D(0, 0);
			Max = new GridPoint2D(size.X, size.Y);
		}

		#region Intersection
		public GridBounds2D GetIntersection(GridBounds2D bounds)
		{
			if(Intersects(bounds))
			{
				int minX = Math.Max(Min.X, bounds.Min.X);
				int minY = Math.Max(Min.Y, bounds.Min.Y);
				int maxX = Math.Min(Max.X, bounds.Max.X);
				int maxY = Math.Min(Max.Y, bounds.Max.Y);
				return new GridBounds2D(minX, minY, maxX, maxY);
			}
			return new GridBounds2D(0, 0, 0, 0);
		}

		public bool Intersects(GridBounds2D bounds)
		{
			GridPoint2D otherMin = bounds.Min;
			GridPoint2D otherMax = bounds.Max;
			return !(Min.X > otherMax.X || Min.Y > otherMax.Y
				|| Max.X < otherMin.X || Max.Y < otherMin.Y);
		}
		#endregion

		#region Contains
		public bool Contains(GridBounds2D bounds)
		{
			return Contains(bounds.Min) && Contains(bounds.Max, true);
		}

		public bool Contains(GridCoord2D coord, bool inclusive = false)
		{
			return Contains(coord.Point, inclusive);
		}

		public bool Contains(GridPoint2D point, bool inclusive = false)
		{
			if(Min.X <= point.X && Min.Y <= point.Y)
			{
				if(inclusive)
				{
					return (Max.X >= point.X && Max.Y >= point.Y);
				}
				return (Max.X > point.X && Max.Y > point.Y);
			}
			return false;
		}
		#endregion

		public override bool Equals(object obj)
		{
			if(obj is GridBounds2D other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(GridBounds2D other)
		{
			return Min == other.Min && Max == other.Max;
		}

		public override int GetHashCode()
		{
			int hash = 17;
			hash = (hash * 23) + Min.GetHashCode();
			hash = (hash * 23) + Max.GetHashCode();
			return hash;
		}

		public override string ToString()
		{
			return $"({nameof(Min)}: {Min}, {nameof(Max)}: {Max})";
		}
	}
}
