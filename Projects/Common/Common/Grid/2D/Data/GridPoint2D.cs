using System;

namespace ProceduralLevel.Common.Grid
{
	public readonly struct GridPoint2D: IEquatable<GridPoint2D>
	{
		public readonly int X;
		public readonly int Y;

		public GridPoint2D(int x, int y)
		{
			X = x;
			Y = y;
		}

		public static GridPoint2D Create(GridAxes2D axes, int a, int b)
		{
			GridPoint2D coord = new GridPoint2D(a, b);
			int x = coord.Get(axes.A);
			int y = coord.Get(axes.B);
			return new GridPoint2D(x, y);
		}

		public GridPoint2D Transform(EDirection2D direction, int distance)
		{
			switch(direction)
			{
				case EDirection2D.Up:
					return new GridPoint2D(X, Y+distance);
				case EDirection2D.Down:
					return new GridPoint2D(X, Y-distance);
				case EDirection2D.Right:
					return new GridPoint2D(X+distance, Y);
				case EDirection2D.Left:
					return new GridPoint2D(X-distance, Y);
				default:
					throw new NotImplementedException();
			}
		}

		public int Get(EGridAxis2D axis)
		{
			switch(axis)
			{
				case EGridAxis2D.X:
					return X;
				case EGridAxis2D.Y:
					return Y;
			}
			throw new NotImplementedException();
		}

		public GridPoint2D Set(EGridAxis2D axis, int value)
		{
			switch(axis)
			{
				case EGridAxis2D.X:
					return new GridPoint2D(value, Y);
				case EGridAxis2D.Y:
					return new GridPoint2D(X, value);
				default:
					throw new NotImplementedException();
			}
		}

		public bool Equals(GridPoint2D other)
		{
			return X == other.X && Y == other.Y;
		}

		public override string ToString()
		{
			return $"({X}, {Y})";
		}
	}
}
