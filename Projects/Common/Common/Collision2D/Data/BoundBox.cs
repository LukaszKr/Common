namespace ProceduralLevel.Common.Collision2D
{
	public struct BoundBox
	{
		public readonly Point Position;
		public readonly Size Size;

		public BoundBox(float x, float y, float width, float height)
		{
			Position = new Point(x, y);
			Size = new Size(width, height);
		}

		public BoundBox(Point position, Size size)
		{
			Position = position;
			Size = size;
		}

		public override string ToString()
		{
			return string.Format("[Position: {0}, Size: {1}]", Position.ToString(), Size.ToString());
		}
	}
}
