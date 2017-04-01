using System;

namespace ProceduralLevel.Common.Event
{
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
