namespace ProceduralLevel.Common.Grid
{
	public readonly struct GridAxisIterator3D
	{
		public readonly EGridAxis3D Axis;
		public readonly int StartIndex;
		public readonly int Step;

		public GridAxisIterator3D(EGridAxis3D axis, GridCoord3D startCoord, GridSize3D gridSize)
		{
			Axis = axis;
			StartIndex = startCoord.Index;

			GridIterator3D iterator = new GridIterator3D(gridSize);
			Step = iterator.Get(axis);
		}

		public override string ToString()
		{
			return $"({Axis}, {nameof(StartIndex)}: {StartIndex}, {nameof(Step)}: {Step})";
		}
	}
}
