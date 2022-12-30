using System;

namespace ProceduralLevel.Common.Grid
{
	public readonly struct GridHit3D : IEquatable<GridHit3D>
	{
		public readonly GridIndex3D Index;
		public readonly EDirection3D Face;

		public GridHit3D(GridIndex3D index, EDirection3D face)
		{
			Index = index;
			Face = face;
		}

		public bool Equals(GridHit3D other)
		{
			return (Face == other.Face && Index.Equals(other.Index));
		}

		public override string ToString()
		{
			return $"({Index}, {Face})";
		}
	}
}
