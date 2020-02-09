using System;

namespace ProceduralLevel.Common.Pooling
{
	[Flags]
	public enum EPoolOptions
	{
		None = 0,

		IgnoreOverflow = 1 << 0,

		Default = None
	}

	public static class EPoolOptionsExt
	{
		public static bool Contains(this EPoolOptions option, EPoolOptions other)
		{
			return (option & other) == other;
		}
	}
}
