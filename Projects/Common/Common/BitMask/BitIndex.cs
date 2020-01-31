namespace ProceduralLevel.Common.BitMask
{
	public struct BitIndex
	{
		public readonly byte Group;
		public readonly byte Local;

		public BitIndex(int index)
		{
			int count = 0;
			while(index >= 32)
			{
				index -= 32;
				count++;
			}
			Group = (byte)count;
			Local = (byte)index;
		}

		public override string ToString()
		{
			return $"({Group}, {Local})";
		}
	}
}
