using ProceduralLevel.Common.Event;

namespace ProceduralLevel.Common.Context
{
	public class ContextClass<TContext> : AContextClass<TContext>
		where TContext : class
	{
		private readonly OnDetachDelegate m_OnDetach;
		private readonly OnAttachDelegate m_OnAttach;
		private readonly OnReplaceDelegate m_OnReplace;

		public delegate void OnDetachDelegate();
		public delegate void OnAttachDelegate(EventBinder binder);
		public delegate void OnReplaceDelegate(EventBinder binder, TContext oldContext, TContext newContext);

		public ContextClass(OnAttachDelegate onAttach, OnDetachDelegate onDetach, OnReplaceDelegate onReplace = null)
		{
			m_OnAttach = onAttach;
			m_OnDetach = onDetach;
			m_OnReplace = onReplace;
		}

		protected override void OnAttach(EventBinder binder)
		{
			m_OnAttach(binder);
		}

		protected override void OnDetach()
		{
			m_OnDetach();
		}

		protected override void OnReplace(EventBinder binder, TContext oldContext, TContext newContext)
		{
			if(m_OnReplace != null)
			{
				m_OnReplace(binder, oldContext, newContext);
			}
			else
			{
				base.OnReplace(binder, oldContext, newContext);
			}
		}
	}
}
