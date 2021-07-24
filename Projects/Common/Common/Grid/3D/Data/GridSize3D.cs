using System;

namespace ProceduralLevel.Common.Grid
{
	public readonly struct GridSize3D : IEquatable<GridSize3D>
	{
		public readonly int Length;

		public readonly int X;
		public readonly int Y;
		public readonly int Z;

		public GridSize3D(int x, int y, int z)
		{
			X = x;
			Y = y;
			Z = z;

			Length = X*Y*Z;
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

		public bool Contains(GridPoint3D point)
		{
			return point.X < X && point.Y < Y && point.Z < Z &&
				point.X >= 0 && point.Y >= 0 && point.Z >= 0;
		}

		public bool Contains(GridCoord3D coord)
		{
			return coord.Index < Length;
		}

		public bool Contains(int index)
		{
			return index < Length;
		}

		public bool Equals(GridSize3D other)
		{
			return (X == other.X) && (Y == other.Y) && (Z == other.Z);
		}

		public override string ToString()
		{
			return $"(Length: {Length} ({X}, {Y}, {Z}))";
		}
	}
}
