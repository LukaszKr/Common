﻿using System;

namespace ProceduralLevel.Common.Grid
{
	public readonly struct GridBounds3D : IEquatable<GridBounds3D>
	{
		public readonly GridIndex3D Min;
		public readonly GridIndex3D Max;
		public readonly GridSize3D Size;

		public static bool operator ==(GridBounds3D left, GridBounds3D right) => left.Equals(right);
		public static bool operator !=(GridBounds3D left, GridBounds3D right) => !left.Equals(right);

		public GridBounds3D(int maxX, int maxY, int maxZ)
		{
			Min = new GridIndex3D(0, 0, 0);
			Max = new GridIndex3D(maxX, maxY, maxZ);
			Size = new GridSize3D(maxX, maxY, maxZ);
		}

		public GridBounds3D(int minX, int minY, int minZ, int maxX, int maxY, int maxZ)
		{
			Min = new GridIndex3D(minX, minY, minZ);
			Max = new GridIndex3D(maxX, maxY, maxZ);
			Size = new GridSize3D(maxX-minX, maxY-minY, maxZ-minZ);
		}

		public GridBounds3D(GridIndex3D min, GridIndex3D max)
		{
			Min = min;
			Max = max;
			Size = new GridSize3D(max-min);
		}

		public GridBounds3D(GridIndex3D size)
		{
			Min = new GridIndex3D(0, 0, 0);
			Max = size;
			Size = new GridSize3D(size);
		}

		public GridBounds3D(GridSize3D size)
		{
			Min = new GridIndex3D(0, 0, 0);
			Max = new GridIndex3D(size.X, size.Y, size.Z);
			Size = size;
		}

		public GridBounds3D Combine(GridBounds3D other)
		{
			return new GridBounds3D(Min.Min(other.Min), Max.Max(other.Max));
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
			GridIndex3D otherMin = bounds.Min;
			GridIndex3D otherMax = bounds.Max;
			return !(Min.X > otherMax.X || Min.Y > otherMax.Y || Min.Z > otherMax.Z
				|| Max.X < otherMin.X || Max.Y < otherMin.Y || Max.Z < otherMin.Z);
		}
		#endregion

		#region Contains
		public bool Contains(GridBounds3D bounds)
		{
			return Contains(bounds.Min) && Contains(bounds.Max);
		}

		public bool Contains<TIndex>(TIndex index)
			where TIndex : IGridIndex3D
		{
			if(Min.X <= index.X && Min.Y <= index.Y && Min.Z <= index.Z)
			{
				return (Max.X > index.X && Max.Y > index.Y && Max.Z > index.Z);
			}
			return false;
		}
		#endregion

		public override bool Equals(object obj)
		{
			if(obj is GridBounds3D other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(GridBounds3D other)
		{
			return Min == other.Min && Max == other.Max;
		}

		public override int GetHashCode()
		{
			int hash = 17;
			hash = (hash * 23) + Min.GetHashCode();
			hash = (hash * 23) + Max.GetHashCode();
			return hash;
		}

		public override string ToString()
		{
			return $"({nameof(Min)}: {Min}, {nameof(Max)}: {Max})";
		}
	}
}
