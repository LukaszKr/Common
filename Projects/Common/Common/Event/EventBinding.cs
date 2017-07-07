using System;

namespace ProceduralLevel.Common.Event
{
	public class EventBinding<T0>: IEventBinding
	{
		private Event<T0> m_Target;
		private Action<T0> m_Callback;

		public EventBinding(Event<T0> target, Action<T0> callback)
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

	public class EventBinding<T0, T1>: IEventBinding
	{
		private Event<T0, T1> m_Target;
		private Action<T0, T1> m_Callback;

		public EventBinding(Event<T0, T1> target, Action<T0, T1> callback)
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

	public class EventBinding<T0, T1, T2>: IEventBinding
	{
		private Event<T0, T1, T2> m_Target;
		private Action<T0, T1, T2> m_Callback;

		public EventBinding(Event<T0, T1, T2> target, Action<T0, T1, T2> callback)
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

	public class EventBinding<T0, T1, T2, T3>: IEventBinding
	{
		private Event<T0, T1, T2, T3> m_Target;
		private Action<T0, T1, T2, T3> m_Callback;

		public EventBinding(Event<T0, T1, T2, T3> target, Action<T0, T1, T2, T3> callback)
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
