using System;
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
				throw new InvalidOperationException();
			}

			m_ContextBinder.UnbindAll();
			TContext oldContext = m_Context;
			m_Context = context;
			if(context != null)
			{
				if(oldContext != null)
				{
					OnReplace(m_ContextBinder, oldContext, context);
				}
				else
				{
					OnAttach(m_ContextBinder, context);
				}
			}
			else if(oldContext != null)
			{
				OnDetach();
			}
		}

		protected virtual void OnReplace(EventBinder binder, TContext oldContext, TContext newContext)
		{
			OnDetach();
			OnAttach(binder, newContext);
		}

		protected abstract void OnAttach(EventBinder binder, TContext context);
		protected abstract void OnDetach();
	}
}
