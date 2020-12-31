using System;

namespace ProceduralLevel.Common.Grid
{
	public readonly struct GridPoint3D: IEquatable<GridPoint3D>
	{
		public static readonly GridPoint3D ZERO = new GridPoint3D(0, 0, 0);

		public readonly int X;
		public readonly int Y;
		public readonly int Z;

		public GridPoint3D(int x, int y, int z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public static GridPoint3D Create(GridAxes3D axes, int a, int b, int c)
		{
			GridPoint3D coord = new GridPoint3D(a, b, c);
			int x = coord.Get(axes.A);
			int y = coord.Get(axes.B);
			int z = coord.Get(axes.C);
			return new GridPoint3D(x, y, z);
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

		public GridPoint3D Set(EGridAxis3D axis, int value)
		{
			switch(axis)
			{
				case EGridAxis3D.X:
					return new GridPoint3D(value, Y, Z);
				case EGridAxis3D.Y:
					return new GridPoint3D(X, value, Z);
				case EGridAxis3D.Z:
					return new GridPoint3D(X, Y, value);
				default:
					throw new NotImplementedException();
			}
		}

		#region Other

		public GridPoint3D Translate(EDirection3D direction, int distance)
		{
			switch(direction)
			{
				case EDirection3D.Up:
					return new GridPoint3D(X, Y+distance, Z);
				case EDirection3D.Down:
					return new GridPoint3D(X, Y-distance, Z);
				case EDirection3D.Right:
					return new GridPoint3D(X+distance, Y, Z);
				case EDirection3D.Left:
					return new GridPoint3D(X-distance, Y, Z);
				case EDirection3D.Front:
					return new GridPoint3D(X, Y, Z+distance);
				case EDirection3D.Back:
					return new GridPoint3D(X, Y, Z-distance);
				default:
					throw new NotImplementedException();
			}
		}

		public GridPoint3D Add(GridPoint3D other)
		{
			return new GridPoint3D(
				X+other.X,
				Y+other.Y,
				Z+other.Z
			);
		}

		public GridPoint3D Remove(GridPoint3D other)
		{
			return new GridPoint3D(
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

		public override int GetHashCode()
		{
			int hash = 17;
			hash = hash * 23 + X.GetHashCode();
			hash = hash * 23 + Y.GetHashCode();
			hash = hash * 23 + Z.GetHashCode();
			return hash;
		}

		public bool Equals(GridPoint3D other)
		{
			return X == other.X && Y == other.Y && Z == other.Z;
		}

		public override string ToString()
		{
			return $"({X}, {Y}, {Z})";
		}
	}
}
