using System;

namespace ProceduralLevel.Common.Grid
{
	public readonly struct GridAxes3D : IEquatable<GridAxes3D>
	{
		public readonly EGridAxis3D A;
		public readonly EGridAxis3D B;
		public readonly EGridAxis3D C;

		public static bool operator ==(GridAxes3D left, GridAxes3D right) => left.Equals(right);
		public static bool operator !=(GridAxes3D left, GridAxes3D right) => !left.Equals(right);

		public GridAxes3D(EGridAxis3D a, EGridAxis3D b, EGridAxis3D c)
		{
			A = a;
			B = b;
			C = c;
		}

		public GridAxes3D(EGridAxis3D a, EGridAxis3D b)
		{
			A = a;
			B = b;
			C = EGridAxis3DExt.GetRemainingAxis(A, B);
		}

		public override bool Equals(object obj)
		{
			if(obj is GridAxes3D other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(GridAxes3D other)
		{
			return A == other.A && B == other.B && C == other.C;
		}

		public override int GetHashCode()
		{
			return (int)A + ((int)B << 1) + ((int)C << 2);
		}

		public override string ToString()
		{
			return $"({A}, {B}, {C})";
		}
	}
}
