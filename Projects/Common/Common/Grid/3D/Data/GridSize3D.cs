using System;

namespace ProceduralLevel.Common.Grid
{
	public readonly struct GridSize3D : IEquatable<GridSize3D>
	{
		public readonly int X;
		public readonly int Y;
		public readonly int Z;

		public static bool operator ==(GridSize3D left, GridSize3D right) => left.Equals(right);
		public static bool operator !=(GridSize3D left, GridSize3D right) => !left.Equals(right);

		public GridSize3D(int x, int y, int z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public GridSize3D(GridIndex3D index)
		{
			X = index.X;
			Y = index.Y;
			Z = index.Z;
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

		public int GetMinValue()
		{
			return Math.Min(Math.Min(X, Y), Z);
		}

		public int GetMaxValue()
		{
			return Math.Max(Math.Max(X, Y), Z);
		}

		public float GetAverage()
		{
			return (X+Y+Z)/3f;
		}

		public bool Contains<TIndex>(TIndex index)
			where TIndex : IGridIndex3D
		{
			return index.X < X && index.Y < Y && index.Z < Z &&
				index.X >= 0 && index.Y >= 0 && index.Z >= 0;
		}

		public override bool Equals(object obj)
		{
			if(obj is GridSize3D other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(GridSize3D other)
		{
			return (X == other.X) && (Y == other.Y) && (Z == other.Z);
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
