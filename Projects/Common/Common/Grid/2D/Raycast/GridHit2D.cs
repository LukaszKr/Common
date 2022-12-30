using System;

namespace ProceduralLevel.Common.Grid
{
	public readonly struct GridHit2D : IEquatable<GridHit2D>
	{
		public readonly GridIndex2D Index;
		public readonly EDirection2D Face;

		public GridHit2D(GridIndex2D index, EDirection2D face)
		{
			Index = index;
			Face = face;
		}

		public bool Equals(GridHit2D other)
		{
			return (Face == other.Face && Index.Equals(other.Index));
		}

		public override string ToString()
		{
			return $"({Index}, {Face})";
		}
	}
}
