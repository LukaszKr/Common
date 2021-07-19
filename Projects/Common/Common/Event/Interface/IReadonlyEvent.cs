using System;

namespace ProceduralLevel.Common.Event
{
	public interface IReadonlyEvent<TCallback>
		where TCallback: Delegate
	{
		void AddListener(TCallback callback);
		void RemoveListener(TCallback callback);
	}
}
