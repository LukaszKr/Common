using System;

namespace ProceduralLevel.Common.Grid
{
	public readonly struct GridBounds3D
	{
		public readonly GridPoint3D Min;
		public readonly GridPoint3D Max;

		public int SizeX { get { return Max.X-Min.X; } }
		public int SizeY { get { return Max.Y-Min.Y; } }
		public int SizeZ { get { return Max.Z-Min.Z; } }

		public GridBounds3D(int maxX, int maxY, int maxZ)
		{
			Min = new GridPoint3D(0, 0, 0);
			Max = new GridPoint3D(maxX, maxY, maxZ);
		}

		public GridBounds3D(int minX, int minY, int minZ, int maxX, int maxY, int maxZ)
		{
			Min = new GridPoint3D(minX, minY, minZ);
			Max = new GridPoint3D(maxX, maxY, maxZ);
		}

		public GridBounds3D(GridPoint3D min, GridPoint3D max)
		{
			Min = min;
			Max = max;
		}

		public GridBounds3D(GridSize3D size)
		{
			Min = new GridPoint3D(0, 0, 0);
			Max = new GridPoint3D(size.X, size.Y, size.Z);
		}

		#region Intersection
		public GridBounds3D GetIntersection(GridBounds3D bounds)
		{
			if(Intersects(bounds))
			{
				int minX = Math.Max(Min.X, bounds.Min.X);
				int minY = Math.Max(Min.Y, bounds.Min.Y);
				int minZ = Math.Max(Min.Z, bounds.Min.Z);
				int maxX = Math.Min(Max.X, bounds.Max.X);
				int maxY = Math.Min(Max.Y, bounds.Max.Y);
				int maxZ = Math.Min(Max.Z, bounds.Max.Z);
				return new GridBounds3D(minX, minY, minZ, maxX, maxY, maxZ);
			}
			return new GridBounds3D(0, 0, 0, 0, 0, 0);
		}

		public bool Intersects(GridBounds3D bounds)
		{
			GridPoint3D otherMin = bounds.Min;
			GridPoint3D otherMax = bounds.Max;
			return !(Min.X > otherMax.X || Min.Y > otherMax.Y || Min.Z > otherMax.Z
				|| Max.X < otherMin.X || Max.Y < otherMin.Y || Max.Z < otherMin.Z);
		}
		#endregion

		#region Contains
		public bool Contains(GridBounds3D bounds)
		{
			return Contains(bounds.Min) && Contains(bounds.Max, true);
		}

		public bool Contains(GridCoord3D coord, bool inclusive = false)
		{
			return Contains(coord.Point, inclusive);
		}

		public bool Contains(GridPoint3D point, bool inclusive = false)
		{
			if(Min.X <= point.X && Min.Y <= point.Y && Min.Z <= point.Z)
			{
				if(inclusive)
				{
					return (Max.X >= point.X && Max.Y >= point.Y && Max.Z >= point.Z);
				}
				return (Max.X > point.X && Max.Y > point.Y && Max.Z > point.Z);
			}
			return false;
		}
		#endregion

		public override string ToString()
		{
			return $"({nameof(Min)}: {Min}, {nameof(Max)}: {Max})";
		}
	}
}
