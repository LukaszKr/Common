using ProceduralLevel.Common.Ext;

namespace ProceduralLevel.Common.Grid
{
	public enum EGridAxis2D: byte
	{
		X = 0,
		Y = 1,
	}

	public static class EGridAxis2DExt
	{
		public static readonly EnumExt<EGridAxis2D> Meta = new EnumExt<EGridAxis2D>();
	}
}
