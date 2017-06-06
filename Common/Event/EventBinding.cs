using System;

namespace ProceduralLevel.Common.Event
{
	public class EventBinding<T1>: IEventBinding
	{
		private Event<T1> m_Target;
		private Action<T1> m_Callback;

		public EventBinding(Event<T1> target, Action<T1> callback)
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
