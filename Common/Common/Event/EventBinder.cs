using System;
using System.Collections.Generic;

namespace Common.Event
{
	public abstract class EventBinder<EventIDType>
	{
		private EventManager m_Manager;
		private List<IEventBinding> m_Bindings;
		private bool m_IsDisabled;

		public bool IsDisabled
		{
			get { return m_IsDisabled; }
		}

		public EventBinder(EventManager manager)
		{
			m_Bindings = new List<IEventBinding>();
			m_Manager = manager;
		}

		public abstract bool Bind<EventType>(EventIDType eventID, Action<EventType> callback) where EventType: BaseEvent;

		protected bool Bind<EventType>(int eventID, Action<EventType> callback) where EventType: BaseEvent
		{
			return Bind(m_Manager.GetEventChannel<EventType>(eventID), callback);
		}

		public bool Bind<EventType>(EventChannel<EventType> target, Action<EventType> callback)
		{
			EventBinding<EventType> pair = new EventBinding<EventType>(target, callback);
			m_Bindings.Add(pair);
			if(!IsDisabled)
			{
				pair.Bind();
			}
			return true;
		}

		public void UnbindAll()
		{
			Disable();
			m_Bindings.Clear();
		}

		public void Disable()
		{
			m_IsDisabled = true;
			for(int x = 0; x < m_Bindings.Count; x++)
			{
				m_Bindings[x].Unbind();
			}
		}

		public void Enable()
		{
			m_IsDisabled = false;
			for(int x = 0; x < m_Bindings.Count; x++)
			{
				m_Bindings[x].Bind();
			}
		}
	}
}
