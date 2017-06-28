using System;
using System.Collections.Generic;

namespace ProceduralLevel.Common.Event
{
	public class Event<T1>
	{
		protected List<Action<T1>> m_Listeners = new List<Action<T1>>();

		public override string ToString()
		{
			return string.Format("[EventChannel, EventType: {0}, ListenerCount: {1}]", typeof(T1).Name, m_Listeners.Count);
		}

		public void Invoke(T1 message)
		{
			for(int x = m_Listeners.Count-1; x >= 0; x--)
			{
				m_Listeners[x](message);
			}
		}

		public void AddListener(Action<T1> listener)
		{
			m_Listeners.Add(listener);
		}

		public bool RemoveListener(Action<T1> listener)
		{
			return m_Listeners.Remove(listener);
		}

		public void RemoveAllListeners()
		{
			m_Listeners.Clear();
		}
	}
}
