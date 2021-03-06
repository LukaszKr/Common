﻿using System;

namespace ProceduralLevel.Common.Grid
{
	public readonly struct GridSize2D: IEquatable<GridSize2D>
	{
		public readonly int Length;

		public readonly int X;
		public readonly int Y;

		public GridSize2D(int x, int y)
		{
			X = x;
			Y = y;

			Length = X*Y;
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

		public bool Contains(GridPoint2D point)
		{
			return point.X < X && point.Y < Y &&
				point.X >= 0 && point.Y >= 0;
		}

		public bool Contains(GridCoord2D coord)
		{
			return coord.Index < Length;
		}

		public bool Contains(int index)
		{
			return index < Length;
		}

		public bool Equals(GridSize2D other)
		{
			return (X == other.X) && (Y == other.Y);
		}

		public override string ToString()
		{
			return $"(Length: {Length} ({X}, {Y}))";
		}
	}
}
