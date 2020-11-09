using System;

namespace ProceduralLevel.Common.Collision2D
{
	public struct Size: IEquatable<Size>
	{
		public readonly float Width;
		public readonly float Height;

		public Size(float width, float height)
		{
			Width = width;
			Height = height;
		}

		public bool Equals(Size other)
		{
			return Width == other.Width && Height == other.Height;
		}

		public override string ToString()
		{
			return string.Format("[Width: {0}, Height: {1}]", Width.ToString(), Height.ToString());
		}
	}
}
