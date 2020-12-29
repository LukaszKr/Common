namespace ProceduralLevel.Common.Grid
{
	public readonly struct GridAxes2D
	{
		public static readonly GridAxes2D XY = new GridAxes2D(EGridAxis2D.X, EGridAxis2D.Y);
		public static readonly GridAxes2D YX = new GridAxes2D(EGridAxis2D.Y, EGridAxis2D.X);

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
