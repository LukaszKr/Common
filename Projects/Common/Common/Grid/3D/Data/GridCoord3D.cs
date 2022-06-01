using System;

namespace ProceduralLevel.Common.Grid
{
	public readonly struct GridCoord3D : IEquatable<GridCoord3D>
	{
		public readonly int Index;
		public readonly GridPoint3D Point;

		public static bool operator ==(GridCoord3D left, GridCoord3D right) => left.Equals(right);
		public static bool operator !=(GridCoord3D left, GridCoord3D right) => !left.Equals(right);

		public GridCoord3D(GridPoint3D point, int index)
		{
			Point = point;
			Index = index;
		}

		public GridCoord3D(GridSize3D size, int index)
		{
			Index = index;

			int x = (index % size.X);
			index /= size.X;
			int y = (index % size.Y);
			index /= size.Y;
			int z = index;
			Point = new GridPoint3D(x, y, z);
		}

		public GridCoord3D(GridSize3D size, int x, int y, int z)
			: this(size, new GridPoint3D(x, y, z))
		{
		}

		public GridCoord3D(GridSize3D size, GridPoint3D point)
		{
			Point = point;
			Index = (point.Z*size.X*size.Y)+(point.Y*size.X)+point.X;
		}

		public static GridCoord3D Create(GridSize3D size, GridAxes3D axes, int a, int b, int c)
		{
			GridPoint3D point = GridPoint3D.Create(axes, a, b, c);
			return new GridCoord3D(size, point);
		}

		public GridCoord3D Set(GridSize3D size, EGridAxis3D axis, int value)
		{
			switch(axis)
			{
				case EGridAxis3D.X:
					return new GridCoord3D(size, value, Point.Y, Point.Z);
				case EGridAxis3D.Y:
					return new GridCoord3D(size, Point.X, value, Point.Z);
				case EGridAxis3D.Z:
					return new GridCoord3D(size, Point.X, Point.Y, value);
				default:
					throw new NotImplementedException();
			}
		}

		public override bool Equals(object obj)
		{
			if(obj is GridCoord3D other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(GridCoord3D other)
		{
			return Index == other.Index;
		}

		public override int GetHashCode()
		{
			return Index;
		}

		public override string ToString()
		{
			return $"(Index: {Index} | {Point})";
		}
	}
}
