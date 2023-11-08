using ProceduralLevel.Common.Event;

namespace ProceduralLevel.Common.Context
{
	public abstract class AContextClass<TContext>
	{
		protected TContext m_Context;
		private readonly EventBinder m_ContextBinder = new EventBinder();

		private bool m_ContextIsSet;

		public void ClearContext()
		{
			if(m_ContextIsSet)
			{
				m_ContextIsSet = false;
				m_Context = default;
				OnDetach();
			}
		}

		public void SetContext(TContext context)
		{
			m_ContextBinder.UnbindAll();

			if(m_ContextIsSet)
			{
				TContext oldContext = m_Context;
				m_Context = context;
				OnReplace(m_ContextBinder, oldContext);
			}
			else
			{
				m_ContextIsSet = true;
				m_Context = context;
				OnAttach(m_ContextBinder);
			}
		}

		protected virtual void OnReplace(EventBinder binder, TContext oldContext)
		{
			OnDetach();
			OnAttach(binder);
		}

		protected abstract void OnAttach(EventBinder binder);
		protected abstract void OnDetach();
	}
}
