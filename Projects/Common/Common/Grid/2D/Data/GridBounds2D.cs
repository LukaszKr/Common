using System;

namespace ProceduralLevel.Common.Grid
{
	public readonly struct GridBounds2D : IEquatable<GridBounds2D>
	{
		public readonly GridIndex2D Min;
		public readonly GridIndex2D Max;
		public readonly GridSize2D Size;

		public static bool operator ==(GridBounds2D left, GridBounds2D right) => left.Equals(right);
		public static bool operator !=(GridBounds2D left, GridBounds2D right) => !left.Equals(right);

		public GridBounds2D(int maxX, int maxY)
		{
			Min = new GridIndex2D(0, 0);
			Max = new GridIndex2D(maxX, maxY);
			Size = new GridSize2D(maxX, maxY);
		}

		public GridBounds2D(int minX, int minY, int maxX, int maxY)
		{
			Min = new GridIndex2D(minX, minY);
			Max = new GridIndex2D(maxX, maxY);
			Size = new GridSize2D(maxX-minX, maxY-minY);
		}

		public GridBounds2D(GridIndex2D min, GridIndex2D max)
		{
			Min = min;
			Max = max;
			Size = new GridSize2D(max-min);
		}

		public GridBounds2D(GridIndex2D max)
		{
			Min = new GridIndex2D(0, 0);
			Max = max;
			Size = new GridSize2D(max.X, max.Y);
		}

		public GridBounds2D(GridSize2D size)
		{
			Min = new GridIndex2D(0, 0);
			Max = new GridIndex2D(size.X, size.Y);
			Size = size;
		}

		public GridBounds2D Combine(GridBounds2D other)
		{
			return new GridBounds2D(Min.Min(other.Min), Max.Max(other.Max));
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
			GridIndex2D otherMin = bounds.Min;
			GridIndex2D otherMax = bounds.Max;
			return !(Min.X > otherMax.X || Min.Y > otherMax.Y
				|| Max.X < otherMin.X || Max.Y < otherMin.Y);
		}
		#endregion

		#region Contains
		public bool Contains(GridBounds2D bounds)
		{
			return Contains(bounds.Min) && Contains(bounds.Max);
		}

		public bool Contains<TIndex>(TIndex index)
			where TIndex : IGridIndex2D
		{
			if(Min.X <= index.X && Min.Y <= index.Y)
			{
				return (Max.X > index.X && Max.Y > index.Y);
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
