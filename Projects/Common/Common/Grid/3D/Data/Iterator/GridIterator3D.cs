using System;

namespace ProceduralLevel.Common.Grid
{
	public readonly struct GridIterator3D
	{
		public readonly int X;
		public readonly int Y;
		public readonly int Z;

		public GridIterator3D(GridSize3D size)
		{
			X = 1;
			Y = size.X;
			Z = size.X*size.Y;
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

		public override string ToString()
		{
			return $"({X}, {Y}, {Z})";
		}
	}
}
