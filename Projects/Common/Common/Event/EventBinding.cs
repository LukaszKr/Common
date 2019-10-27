namespace ProceduralLevel.Common.Event
{
	public class EventBinding: IEventBinding
	{
		private AEvent m_Target;
		private AEvent.Callback m_Callback;

		public EventBinding(AEvent target, AEvent.Callback callback)
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
		private AEvent<T0> m_Target;
		private AEvent<T0>.Callback m_Callback;

		public EventBinding(AEvent<T0> target, AEvent<T0>.Callback callback)
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
		private AEvent<T0, T1> m_Target;
		private AEvent<T0, T1>.Callback m_Callback;

		public EventBinding(AEvent<T0, T1> target, AEvent<T0, T1>.Callback callback)
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
		private AEvent<T0, T1, T2> m_Target;
		private AEvent<T0, T1, T2>.Callback m_Callback;

		public EventBinding(AEvent<T0, T1, T2> target, AEvent<T0, T1, T2>.Callback callback)
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
		private AEvent<T0, T1, T2, T3> m_Target;
		private AEvent<T0, T1, T2, T3>.Callback m_Callback;

		public EventBinding(AEvent<T0, T1, T2, T3> target, AEvent<T0, T1, T2, T3>.Callback callback)
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
