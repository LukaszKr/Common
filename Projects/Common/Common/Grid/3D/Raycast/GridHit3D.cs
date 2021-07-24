using System;

namespace ProceduralLevel.Common.Grid
{
	public struct GridHit3D : IEquatable<GridHit3D>
	{
		public readonly GridPoint3D Point;
		public readonly EDirection3D Face;

		public GridHit3D(GridPoint3D point, EDirection3D face)
		{
			Point = point;
			Face = face;
		}

		public bool Equals(GridHit3D other)
		{
			return (Face == other.Face && Point.Equals(other.Point));
		}

		public override string ToString()
		{
			return $"({Point}, {Face})";
		}
	}
}
