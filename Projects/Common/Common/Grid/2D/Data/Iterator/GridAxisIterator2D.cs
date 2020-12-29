namespace ProceduralLevel.Common.Grid
{
	public struct GridAxisIterator2D
	{
		public readonly EGridAxis2D Axis;
		public readonly int StartIndex;
		public readonly int Step;

		public GridAxisIterator2D(EGridAxis2D axis, GridCoord2D startCoord, GridSize2D gridSize)
		{
			Axis = axis;
			StartIndex = startCoord.Index;

			GridIterator2D iterator = new GridIterator2D(gridSize);
			Step = iterator.Get(axis);
		}

		public override string ToString()
		{
			return $"({Axis}, {nameof(StartIndex)}: {StartIndex}, {nameof(Step)}: {Step})";
		}
	}
}
