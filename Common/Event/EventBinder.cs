using System;
using System.Collections.Generic;

namespace ProceduralLevel.Common.Event
{
	public abstract class EventBinder<EventIDType>
	{
		private EventManager m_Manager;
		private List<IEventBinding> m_Bindings;
		
		public bool IsDisabled { get; private set; }

		public override string ToString()
		{
			return string.Format("[EventBinder, EventIDType: {0}, Disabled: {1}", typeof(EventIDType).Name, IsDisabled);
		}

		public EventBinder(EventManager manager)
		{
			m_Bindings = new List<IEventBinding>();
			m_Manager = manager;
		}

		~EventBinder()
		{
			UnbindAll();
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
			for(int x = 0; x < m_Bindings.Count; x++)
			{
				m_Bindings[x].Unbind();
			}
			m_Bindings.Clear();
		}

		public void Disable()
		{
			IsDisabled = true;
			for(int x = 0; x < m_Bindings.Count; x++)
			{
				m_Bindings[x].Unbind();
			}
		}

		public void Enable()
		{
			IsDisabled = false;
			for(int x = 0; x < m_Bindings.Count; x++)
			{
				m_Bindings[x].Bind();
			}
		}
	}
}