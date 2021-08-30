namespace ProceduralLevel.Common.BitMask
{
	public readonly struct BitIndex
	{
		private const int LOOKUP_SIZE = 256;
		private static readonly BitIndex[] m_Cache;

		public readonly byte Group;
		public readonly byte Local;

		static BitIndex()
		{
			int offset = 0;
			int counter = 0;
			m_Cache = new BitIndex[LOOKUP_SIZE];
			for(int x = 0; x < m_Cache.Length; ++x)
			{
				m_Cache[x] = new BitIndex((byte)offset, (byte)counter);
				++counter;
				if(counter == 32)
				{
					counter = 0;
					++offset;
				}
			}
		}

		private BitIndex(byte group, byte local)
		{
			Group = group;
			Local = local;
		}

		public static BitIndex Get(int index)
		{
			return m_Cache[index];
		}

		public override string ToString()
		{
			return $"({Group}, {Local})";
		}
	}
}
