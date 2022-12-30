using System;

namespace ProceduralLevel.Common.Grid
{
	public readonly struct GridPoint2D : IEquatable<GridPoint2D>
	{
		public readonly int X;
		public readonly int Y;

		public static bool operator ==(GridPoint2D left, GridPoint2D right) => left.Equals(right);
		public static bool operator !=(GridPoint2D left, GridPoint2D right) => !left.Equals(right);

		public static GridPoint2D operator +(GridPoint2D left, GridPoint2D right) => left.Add(right);
		public static GridPoint2D operator -(GridPoint2D left, GridPoint2D right) => left.Remove(right);

		public GridPoint2D(int x, int y)
		{
			X = x;
			Y = y;
		}

		public GridPoint2D(EDirection2D direction, int length = 1)
		{
			X = 0;
			Y = 0;

			switch(direction)
			{
				case EDirection2D.Up:
					Y = length;
					break;
				case EDirection2D.Down:
					Y = -length;
					break;
				case EDirection2D.Left:
					X = -length;
					break;
				case EDirection2D.Right:
					X = length;
					break;
				default:
					throw new NotImplementedException();
			}
		}

		public static GridPoint2D Create(GridAxes2D axes, int a, int b)
		{
			GridPoint2D coord = new GridPoint2D(a, b);
			int x = coord.Get(axes.A);
			int y = coord.Get(axes.B);
			return new GridPoint2D(x, y);
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

		#region Math
		public GridPoint2D Add(GridPoint2D other)
		{
			return new GridPoint2D(
				X+other.X,
				Y+other.Y
			);
		}

		public GridPoint2D Remove(GridPoint2D other)
		{
			return new GridPoint2D(
				X-other.X,
				Y-other.Y
			);
		}

		public int GetMinValue()
		{
			return Math.Min(X, Y);
		}

		public int GetMaxValue()
		{
			return Math.Max(X, Y);
		}
		#endregion

		#region Other
		public GridPoint2D Translate(EGridAxis2D axis, int distance)
		{
			switch(axis)
			{
				case EGridAxis2D.X:
					return new GridPoint2D(X+distance, Y);
				case EGridAxis2D.Y:
					return new GridPoint2D(X, Y+distance);
				default:
					throw new NotImplementedException();
			}
		}

		public GridPoint2D Translate(EDirection2D direction, int distance)
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

		public GridPoint2D Min(GridPoint2D other)
		{
			int x = Math.Min(X, other.X);
			int y = Math.Min(Y, other.Y);
			return new GridPoint2D(x, y);
		}

		public GridPoint2D Max(GridPoint2D other)
		{
			int x = Math.Max(X, other.X);
			int y = Math.Max(Y, other.Y);
			return new GridPoint2D(x, y);
		}
		#endregion

		public override bool Equals(object obj)
		{
			if(obj is GridPoint2D other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(GridPoint2D other)
		{
			return X == other.X && Y == other.Y;
		}

		public override int GetHashCode()
		{
			int hash = 17;
			hash = (hash * 23) + X.GetHashCode();
			hash = (hash * 23) + Y.GetHashCode();
			return hash;
		}

		public override string ToString()
		{
			return $"({X}, {Y})";
		}
	}
}
