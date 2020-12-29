using System;

namespace ProceduralLevel.Common.Grid
{
	public readonly struct GridIterator2D
	{
		public readonly int X;
		public readonly int Y;

		public GridIterator2D(GridSize2D size)
		{
			X = 1;
			Y = size.X;
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

		public override string ToString()
		{
			return $"({X}, {Y})";
		}
	}
}
