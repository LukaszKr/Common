using System;

namespace ProceduralLevel.Common.Grid
{
	public readonly struct GridIndex2D : IEquatable<GridIndex2D>, IGridIndex2D
	{
		public int X { get; }
		public int Y { get; }

		public static bool operator ==(GridIndex2D left, GridIndex2D right) => left.Equals(right);
		public static bool operator !=(GridIndex2D left, GridIndex2D right) => !left.Equals(right);

		public static GridIndex2D operator +(GridIndex2D left, GridIndex2D right) => left.Add(right);
		public static GridIndex2D operator -(GridIndex2D left, GridIndex2D right) => left.Remove(right);

		public GridIndex2D(int x, int y)
		{
			X = x;
			Y = y;
		}

		public GridIndex2D(GridSize2D size)
		{
			X = size.X;
			Y = size.Y;
		}

		public GridIndex2D(GridIndex2D index)
		{
			X = index.X;
			Y = index.Y;
		}

		public GridIndex2D(IGridIndex2D index)
		{
			X = index.X;
			Y = index.Y;
		}

		public GridIndex2D(EDirection2D direction, int length = 1)
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

		public static GridIndex2D Create(GridAxes2D axes, int a, int b)
		{
			GridIndex2D coord = new GridIndex2D(a, b);
			int x = coord.Get(axes.A);
			int y = coord.Get(axes.B);
			return new GridIndex2D(x, y);
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

		public GridIndex2D Set(EGridAxis2D axis, int value)
		{
			switch(axis)
			{
				case EGridAxis2D.X:
					return new GridIndex2D(value, Y);
				case EGridAxis2D.Y:
					return new GridIndex2D(X, value);
				default:
					throw new NotImplementedException();
			}
		}

		#region Math
		public GridIndex2D Add(GridIndex2D other)
		{
			return new GridIndex2D(
				X+other.X,
				Y+other.Y
			);
		}

		public GridIndex2D Remove(GridIndex2D other)
		{
			return new GridIndex2D(
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
		public GridIndex2D Translate(EGridAxis2D axis, int distance = 1)
		{
			switch(axis)
			{
				case EGridAxis2D.X:
					return new GridIndex2D(X+distance, Y);
				case EGridAxis2D.Y:
					return new GridIndex2D(X, Y+distance);
				default:
					throw new NotImplementedException();
			}
		}

		public GridIndex2D Translate(EDirection2D direction, int distance = 1)
		{
			switch(direction)
			{
				case EDirection2D.Up:
					return new GridIndex2D(X, Y+distance);
				case EDirection2D.Down:
					return new GridIndex2D(X, Y-distance);
				case EDirection2D.Right:
					return new GridIndex2D(X+distance, Y);
				case EDirection2D.Left:
					return new GridIndex2D(X-distance, Y);
				default:
					throw new NotImplementedException();
			}
		}

		public GridIndex2D Min(GridIndex2D other)
		{
			int x = Math.Min(X, other.X);
			int y = Math.Min(Y, other.Y);
			return new GridIndex2D(x, y);
		}

		public GridIndex2D Max(GridIndex2D other)
		{
			int x = Math.Max(X, other.X);
			int y = Math.Max(Y, other.Y);
			return new GridIndex2D(x, y);
		}
		#endregion

		public override bool Equals(object obj)
		{
			if(obj is GridIndex2D other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(GridIndex2D other)
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
