using System;

namespace ProceduralLevel.Common.Grid
{
	public readonly struct GridSize2D : IEquatable<GridSize2D>
	{
		public readonly int X;
		public readonly int Y;

		public static bool operator ==(GridSize2D left, GridSize2D right) => left.Equals(right);
		public static bool operator !=(GridSize2D left, GridSize2D right) => !left.Equals(right);

		public GridSize2D(int x, int y)
		{
			X = x;
			Y = y;
		}

		public GridSize2D(GridIndex2D index)
		{
			X = index.X;
			Y = index.Y;
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

		public bool Contains<TIndex>(TIndex index)
			where TIndex : IGridIndex2D
		{
			return index.X < X && index.Y < Y &&
				index.X >= 0 && index.Y >= 0;
		}

		public override bool Equals(object obj)
		{
			if(obj is GridSize2D other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(GridSize2D other)
		{
			return (X == other.X) && (Y == other.Y);
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
