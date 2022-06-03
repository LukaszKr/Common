using System;

namespace ProceduralLevel.Common.Grid
{
	public readonly struct GridAxes2D : IEquatable<GridAxes2D>
	{
		public readonly EGridAxis2D A;
		public readonly EGridAxis2D B;

		public static bool operator ==(GridAxes2D left, GridAxes2D right) => left.Equals(right);
		public static bool operator !=(GridAxes2D left, GridAxes2D right) => !left.Equals(right);

		public GridAxes2D(EGridAxis2D a, EGridAxis2D b)
		{
			A = a;
			B = b;
		}

		public override bool Equals(object obj)
		{
			if(obj is GridAxes2D other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(GridAxes2D other)
		{
			return A == other.A && B == other.B;
		}

		public override int GetHashCode()
		{
			return (int)A + ((int)B << 1);
		}

		public override string ToString()
		{
			return $"({A}, {B})";
		}
	}
}
