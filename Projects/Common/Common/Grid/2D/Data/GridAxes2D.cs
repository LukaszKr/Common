namespace ProceduralLevel.Common.Grid
{
	public readonly struct GridAxes2D
	{
		public readonly EGridAxis2D A;
		public readonly EGridAxis2D B;

		public GridAxes2D(EGridAxis2D a, EGridAxis2D b)
		{
			A = a;
			B = b;
		}

		public override string ToString()
		{
			return $"({A}, {B})";
		}
	}
}
