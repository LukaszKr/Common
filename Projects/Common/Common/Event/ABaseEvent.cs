using System;
using System.Collections.Generic;

namespace ProceduralLevel.Common.Event
{
	public abstract class ABaseEvent<TCallback>
		where TCallback: Delegate
	{
		protected readonly List<TCallback> m_Listeners = new List<TCallback>();

		public int ListenerCount { get { return m_Listeners.Count; } }

		public void AddListener(TCallback listener)
		{
			m_Listeners.Add(listener);
		}

		public bool RemoveListener(TCallback listener)
		{
			return m_Listeners.Remove(listener);
		}

		public void RemoveAllListeners()
		{
			m_Listeners.Clear();
		}

		public override string ToString()
		{
			return $"[{GetType().Name}, ListenerCount: {m_Listeners.Count}]";
		}
	}
}
