using ProceduralLevel.Common.Event;

namespace ProceduralLevel.Common.Context
{
	public abstract class AContextClass<TContext>
		where TContext : class
	{
		protected TContext m_Context;
		private readonly EventBinder m_ContextBinder = new EventBinder();

		public TContext Context { get { return m_Context; } }

		public void SetContext(TContext context)
		{
			if(context == m_Context)
			{
				return;
			}

			m_ContextBinder.UnbindAll();
			TContext oldContext = m_Context;
			m_Context = context;
			if(context != null)
			{
				if(oldContext != null)
				{
					OnReplace(m_ContextBinder, oldContext);
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

		protected virtual void OnReplace(EventBinder binder, TContext oldContext)
		{
			OnDetach();
			OnAttach(binder);
		}

		protected abstract void OnAttach(EventBinder binder);
		protected abstract void OnDetach();
	}
}
