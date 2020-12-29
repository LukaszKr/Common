using System;

namespace ProceduralLevel.Common.Grid
{
	public struct VoxelHit: IEquatable<VoxelHit>
	{
		public readonly GridPoint3D Point;
		public readonly EDirection3D Face;

		public VoxelHit(GridPoint3D point, EDirection3D face)
		{
			Point = point;
			Face = face;
		}

		public bool Equals(VoxelHit other)
		{
			return (Face == other.Face && Point.Equals(other.Point));
		}

		public override string ToString()
		{
			return $"({Point}, {Face})";
		}
	}
}
