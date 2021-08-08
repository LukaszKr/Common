using System.Collections.Generic;

namespace ProceduralLevel.Common.Collection
{
	public class UniqueCollection<TEntry> : UniqueCollection<TEntry, TEntry>, IReadonlyUniqueCollection<TEntry>
		where TEntry : class, IUnique<TEntry>
	{

	}

	public class UniqueCollection<TUID, TEntry> : IReadonlyUniqueCollection<TUID, TEntry>
		where TUID : class
		where TEntry : class, IUnique<TUID>
	{
		private readonly List<TEntry> _entries;
		private readonly Dictionary<UID<TUID>, TEntry> _lookup;

		public IReadOnlyList<TEntry> Entries { get { return _entries; } }
		public int Count { get { return _entries.Count; } }

		public UniqueCollection()
		{
			_entries = new List<TEntry>();
			_lookup = new Dictionary<UID<TUID>, TEntry>(UniqueIDComparer<TUID>.Instance);
		}

		public void Clear()
		{
			_entries.Clear();
			_lookup.Clear();
		}

		public bool Contains(TEntry entry)
		{
			return _lookup.ContainsKey(entry.GetID());
		}

		public bool Contains(UID<TUID> id)
		{
			return _lookup.ContainsKey(id);
		}

		public TEntry Find(UID<TUID> id)
		{
			TEntry entry;
			_lookup.TryGetValue(id, out entry);
			return entry;
		}

		public TEntry Get(UID<TUID> id)
		{
			return _lookup[id];
		}

		public void Add(TEntry entry)
		{
			UID<TUID> id = entry.GetID();
			_lookup.Add(id, entry);
			_entries.Add(entry);
		}

		public void AddRange(TEntry[] entries)
		{
			int length = entries.Length;
			for(int x = 0; x < length; ++x)
			{
				TEntry entry = entries[x];
				Add(entry);
			}
		}

		public void AddRange(IReadOnlyCollection<TEntry> collection)
		{
			foreach(TEntry entry in collection)
			{
				Add(entry);
			}
		}

		public TEntry Remove(UID<TUID> id)
		{
			TEntry entry = _lookup[id];
			_lookup.Remove(id);
			_entries.Remove(entry);
			return entry;
		}

		public void Remove(TEntry entry)
		{
			UID<TUID> id = entry.GetID();
			_lookup.Remove(id);
			_entries.Remove(entry);
		}
	}
}
