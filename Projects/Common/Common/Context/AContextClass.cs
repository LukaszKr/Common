using ProceduralLevel.Common.Event;

namespace ProceduralLevel.Common.Context
{
	public abstract class AContextClass<TContext>
		where TContext : class
	{
		protected TContext m_Value;
		private readonly EventBinder m_ContextBinder = new EventBinder();

		public TContext Value { get { return m_Value; } }

		public void SetValue(TContext value)
		{
			if(value == m_Value)
			{
				return;
			}

			m_ContextBinder.UnbindAll();
			TContext oldValue = m_Value;
			m_Value = value;
			if(value != null)
			{
				if(oldValue != null)
				{
					OnReplace(m_ContextBinder, oldValue);
				}
				else
				{
					OnAttach(m_ContextBinder);
				}
			}
			else
			{
				OnDetach();
			}
		}

		protected virtual void OnReplace(EventBinder binder, TContext oldValue)
		{
			OnDetach();
			OnAttach(binder);
		}

		protected abstract void OnAttach(EventBinder binder);
		protected abstract void OnDetach();
	}
}
