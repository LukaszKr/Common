namespace ProceduralLevel.Common.Grid
{
	public struct GridAxes3D
	{
		public readonly EGridAxis3D A;
		public readonly EGridAxis3D B;
		public readonly EGridAxis3D C;

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

		public override string ToString()
		{
			return $"({A}, {B}, {C})";
		}
	}
}
