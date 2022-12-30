using System;

namespace ProceduralLevel.Common.Grid
{
	public readonly struct GridIndex3D : IEquatable<GridIndex3D>
	{
		public static readonly GridIndex3D ZERO = new GridIndex3D(0, 0, 0);

		public readonly int X;
		public readonly int Y;
		public readonly int Z;

		public static bool operator ==(GridIndex3D left, GridIndex3D right) => left.Equals(right);
		public static bool operator !=(GridIndex3D left, GridIndex3D right) => !left.Equals(right);
		public static GridIndex3D operator +(GridIndex3D left, GridIndex3D right) => left.Add(right);
		public static GridIndex3D operator -(GridIndex3D left, GridIndex3D right) => left.Remove(right);

		public GridIndex3D
			(int x, int y, int z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public GridIndex3D(EDirection3D direction, int length = 1)
		{
			X = 0;
			Y = 0;
			Z = 0;

			switch(direction)
			{
				case EDirection3D.Up:
					Y = length;
					break;
				case EDirection3D.Down:
					Y = -length;
					break;
				case EDirection3D.Right:
					X = length;
					break;
				case EDirection3D.Left:
					X = -length;
					break;
				case EDirection3D.Front:
					Z = length;
					break;
				case EDirection3D.Back:
					Z = -length;
					break;
				default:
					throw new NotImplementedException();
			}
		}

		public static GridIndex3D Create(GridAxes3D axes, int a, int b, int c)
		{
			GridIndex3D coord = new GridIndex3D(a, b, c);
			int x = coord.Get(axes.A);
			int y = coord.Get(axes.B);
			int z = coord.Get(axes.C);
			return new GridIndex3D(x, y, z);
		}

		public int Get(EGridAxis3D axis)
		{
			switch(axis)
			{
				case EGridAxis3D.X:
					return X;
				case EGridAxis3D.Y:
					return Y;
				case EGridAxis3D.Z:
					return Z;
			}
			throw new NotImplementedException();
		}

		public GridIndex3D Set(EGridAxis3D axis, int value)
		{
			switch(axis)
			{
				case EGridAxis3D.X:
					return new GridIndex3D(value, Y, Z);
				case EGridAxis3D.Y:
					return new GridIndex3D(X, value, Z);
				case EGridAxis3D.Z:
					return new GridIndex3D(X, Y, value);
				default:
					throw new NotImplementedException();
			}
		}

		#region Math
		public GridIndex3D Add(GridIndex3D other)
		{
			return new GridIndex3D(
				X+other.X,
				Y+other.Y,
				Z+other.Z
			);
		}

		public GridIndex3D Remove(GridIndex3D other)
		{
			return new GridIndex3D(
				X-other.X,
				Y-other.Y,
				Z-other.Z
			);
		}

		public int GetMinValue()
		{
			return Math.Min(Math.Min(X, Y), Z);
		}

		public int GetMaxValue()
		{
			return Math.Max(Math.Max(X, Y), Z);
		}
		#endregion

		#region Other
		public GridIndex3D Rotate(EDirection3D direction)
		{
			switch(direction)
			{
				case EDirection3D.Up:
					return new GridIndex3D(X, -Z, Y);
				case EDirection3D.Down:
					return new GridIndex3D(X, Z, -Y);
				case EDirection3D.Front:
					return new GridIndex3D(-X, Y, -Z);
				case EDirection3D.Back:
					return new GridIndex3D(X, Y, Z);
				case EDirection3D.Left:
					return new GridIndex3D(-Z, Y, X);
				case EDirection3D.Right:
					return new GridIndex3D(Z, Y, -X);
				default:
					throw new NotImplementedException();
			}
		}

		public GridIndex3D Translate(EGridAxis3D axis, int distance)
		{
			switch(axis)
			{
				case EGridAxis3D.X:
					return new GridIndex3D(X+distance, Y, Z);
				case EGridAxis3D.Y:
					return new GridIndex3D(X, Y+distance, Z);
				case EGridAxis3D.Z:
					return new GridIndex3D(X, Y, Z+distance);
				default:
					throw new NotImplementedException();
			}
		}

		public GridIndex3D Translate(EDirection3D direction, int distance)
		{
			switch(direction)
			{
				case EDirection3D.Up:
					return new GridIndex3D(X, Y+distance, Z);
				case EDirection3D.Down:
					return new GridIndex3D(X, Y-distance, Z);
				case EDirection3D.Right:
					return new GridIndex3D(X+distance, Y, Z);
				case EDirection3D.Left:
					return new GridIndex3D(X-distance, Y, Z);
				case EDirection3D.Front:
					return new GridIndex3D(X, Y, Z+distance);
				case EDirection3D.Back:
					return new GridIndex3D(X, Y, Z-distance);
				default:
					throw new NotImplementedException();
			}
		}

		public GridIndex3D Min(GridIndex3D other)
		{
			int x = Math.Min(X, other.X);
			int y = Math.Min(Y, other.Y);
			int z = Math.Min(Z, other.Z);
			return new GridIndex3D(x, y, z);
		}

		public GridIndex3D Max(GridIndex3D other)
		{
			int x = Math.Max(X, other.X);
			int y = Math.Max(Y, other.Y);
			int z = Math.Max(Z, other.Z);
			return new GridIndex3D(x, y, z);
		}
		#endregion

		public override bool Equals(object obj)
		{
			if(obj is GridIndex3D other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(GridIndex3D other)
		{
			return X == other.X && Y == other.Y && Z == other.Z;
		}

		public override int GetHashCode()
		{
			int hash = 17;
			hash = (hash * 23) + X.GetHashCode();
			hash = (hash * 23) + Y.GetHashCode();
			hash = (hash * 23) + Z.GetHashCode();
			return hash;
		}

		public override string ToString()
		{
			return $"({X}, {Y}, {Z})";
		}
	}
}
