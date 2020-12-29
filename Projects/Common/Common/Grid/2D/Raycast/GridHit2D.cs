using System;

namespace ProceduralLevel.Common.Grid
{
	public struct GridHit2D: IEquatable<GridHit2D>
	{
		public readonly GridPoint2D Point;
		public readonly EDirection2D Face;

		public GridHit2D(GridPoint2D point, EDirection2D face)
		{
			Point = point;
			Face = face;
		}

		public bool Equals(GridHit2D other)
		{
			return (Face == other.Face && Point.Equals(other.Point));
		}

		public override string ToString()
		{
			return $"({Point}, {Face})";
		}
	}
}
