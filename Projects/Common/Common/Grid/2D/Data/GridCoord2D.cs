using System;

namespace ProceduralLevel.Common.Grid
{
	public readonly struct GridCoord2D : IEquatable<GridCoord2D>
	{
		public readonly int Index;
		public readonly GridPoint2D Point;

		public GridCoord2D(GridPoint2D point, int index)
		{
			Point = point;
			Index = index;
		}

		public GridCoord2D(GridSize2D size, int index)
		{
			Index = index;

			int x = (index % size.X);
			index /= size.X;
			int y = index;
			Point = new GridPoint2D(x, y);
		}

		public GridCoord2D(GridSize2D size, int x, int y)
			: this(size, new GridPoint2D(x, y))
		{
		}

		public GridCoord2D(GridSize2D size, GridPoint2D point)
		{
			Point = point;
			Index = (point.Y*size.X)+point.X;
		}

		public static GridCoord2D Create(GridSize2D size, GridAxes2D axes, int a, int b)
		{
			GridPoint2D point = GridPoint2D.Create(axes, a, b);
			return new GridCoord2D(size, point);
		}

		public GridCoord2D Set(GridSize2D size, EGridAxis2D axis, int value)
		{
			switch(axis)
			{
				case EGridAxis2D.X:
					return new GridCoord2D(size, value, Point.Y);
				case EGridAxis2D.Y:
					return new GridCoord2D(size, Point.X, value);
				default:
					throw new NotImplementedException();
			}
		}

		public bool Equals(GridCoord2D other)
		{
			return Index == other.Index;
		}

		public override string ToString()
		{
			return $"(Index: {Index} | {Point})";
		}
	}
}
