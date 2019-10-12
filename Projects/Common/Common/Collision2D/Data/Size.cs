namespace ProceduralLevel.Common.Collision2D
{
	public struct Size
	{
		public readonly float Width;
		public readonly float Height;
		
		public Size(float width, float height)
		{
			Width = width;
			Height = height;
		}

		public override string ToString()
		{
			return string.Format("[Width: {0}, Height: {1}]", Width.ToString(), Height.ToString());
		}
	}
}
