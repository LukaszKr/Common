namespace ProceduralLevel.Common.Collision2D
{
	public struct Ellipse
	{
		public readonly Point Position;
		public readonly Size Size;

		public Ellipse(float x, float y, float width, float height)
		{
			Position = new Point(x, y);
			Size = new Size(width, height);
		}

		public Ellipse(Point position, Size size)
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
