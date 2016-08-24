using System;
using System.Collections.Generic;

namespace ProceduralLevel.Common.Event
{
	public class EventChannel<EventType>
	{
		protected List<Action<EventType>> m_Listeners = new List<Action<EventType>>();

		public void Invoke(EventType message)
		{
			for(int x = m_Listeners.Count-1; x >= 0; x--)
			{
				m_Listeners[x](message);
			}
		}

		public bool AddListener(Action<EventType> listener)
		{
			if(m_Listeners.Contains(listener))
			{
				return false;
			}
			m_Listeners.Add(listener);
			return true;
		}

		public bool RemoveListener(Action<EventType> listener)
		{
			return m_Listeners.Remove(listener);
		}

		public void RemoveAllListeners()
		{
			m_Listeners.Clear();
		}
	}

	public class EventBinding<EventType>: IEventBinding
	{
		private EventChannel<EventType> m_Target;
		private Action<EventType> m_Callback;

		public EventBinding(EventChannel<EventType> target, Action<EventType> callback)
		{
			m_Target = target;
			m_Callback = callback;
		}

		public void Bind()
		{
			m_Target.AddListener(m_Callback);
		}

		public void Unbind()
		{
			m_Target.RemoveListener(m_Callback);
		}
	}
}
