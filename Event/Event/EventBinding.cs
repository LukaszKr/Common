namespace ProceduralLevel.Common.Event
{
	public class EventBinding: IEventBinding
	{
		private Event m_Target;
		private Event.Callback m_Callback;

		public EventBinding(Event target, Event.Callback callback)
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

	public class EventBinding<T0>: IEventBinding
	{
		private Event<T0> m_Target;
		private Event<T0>.Callback m_Callback;

		public EventBinding(Event<T0> target, Event<T0>.Callback callback)
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
		private Event<T0, T1>.Callback m_Callback;

		public EventBinding(Event<T0, T1> target, Event<T0, T1>.Callback callback)
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
		private Event<T0, T1, T2>.Callback m_Callback;

		public EventBinding(Event<T0, T1, T2> target, Event<T0, T1, T2>.Callback callback)
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
		private Event<T0, T1, T2, T3>.Callback m_Callback;

		public EventBinding(Event<T0, T1, T2, T3> target, Event<T0, T1, T2, T3>.Callback callback)
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
