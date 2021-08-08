using System.Collections.Generic;

namespace ProceduralLevel.Common.Collection
{
	public interface IReadonlyUniqueCollection<TEntry> : IReadonlyUniqueCollection<TEntry, TEntry>
		where TEntry : class, IUnique<TEntry>
	{

	}

	public interface IReadonlyUniqueCollection<TUIDEntry, TEntry>
		where TEntry : class, IUnique<TUIDEntry>
		where TUIDEntry : class
	{
		IReadOnlyList<TEntry> Entries { get; }
		int Count { get; }

		TEntry Find(UID<TUIDEntry> id);
		TEntry Get(UID<TUIDEntry> id);
	}
}
