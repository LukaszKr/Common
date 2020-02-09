using System.Collections.Generic;

namespace ProceduralLevel.Common.Pooling
{
	public sealed class Pool<TEntry>
		where TEntry : IPoolEntry
	{
		private readonly Stack<TEntry> m_Pool;
		private readonly int m_Capacity;

		private readonly EPoolOptions m_Options;

		public delegate TEntry FactoryDelegate();
		private readonly FactoryDelegate m_Factory;

		public Pool(int initialCapacity, EPoolOptions options, FactoryDelegate factory)
		{
			m_Pool = new Stack<TEntry>(initialCapacity);
			m_Capacity = initialCapacity;

			m_Options = options;
			m_Factory = factory;
		}

		public void Prefill()
		{
			for(int x = 0; x < m_Capacity; ++x)
			{
				Return(m_Factory());
			}
		}

		public TEntry Get()
		{
			if(m_Pool.Count > 0)
			{
				TEntry pooled = m_Pool.Pop();
				pooled.OnGetFromPool();
				return pooled;
			}
			return m_Factory();
		}

		public void Get(TEntry[] entries)
		{
			int length = entries.Length;
			for(int x = 0; x < length; ++x)
			{
				entries[x] = Get();
			}
		}

		public void Return(TEntry entry)
		{
			if(entry != null && !m_Options.Contains(EPoolOptions.IgnoreOverflow) && m_Pool.Count < m_Capacity)
			{
				entry.OnReturnToPool();
				m_Pool.Push(entry);
			}
		}

		public void Return(TEntry[] entries)
		{
			int length = entries.Length;
			for(int x = 0; x < length; ++x)
			{
				TEntry entry = entries[x];
				Return(entry);
			}
		}
	}
}
