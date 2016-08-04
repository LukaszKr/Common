using Common.Helper;

namespace Common.Action
{
	public class ActionManager<DataType>
	{
		public const int INITIAL_CONTEXT_DEPTH = 8;

		private ArrayList<ActionContext<DataType>> m_Contexts = new ArrayList<ActionContext<DataType>>(INITIAL_CONTEXT_DEPTH);
		private DataType m_Data;
		private bool m_Paused;
		private int m_CurrentContext = 0;
		private bool m_Executing;

		public bool Paused { get { return m_Paused; } }

		public ActionManager(DataType data)
		{
			m_Data = data;
			for(int x = 0; x < INITIAL_CONTEXT_DEPTH; x++)
			{
				m_Contexts.Add(new ActionContext<DataType>(x));
			}
		}

		public void AddPendingAction(BaseAction<DataType> action)
		{
			if(m_Executing)
			{
				GetContext(m_CurrentContext+1).PushAction(action);
			}
			else
			{
				GetContext(0).PushAction(action);
			}
		}

		private ActionContext<DataType> GetContext(int depth)
		{
			if(depth >= m_Contexts.Count)
			{
				for(int x = m_Contexts.Count; x < depth; x++)
				{
					m_Contexts.Add(new ActionContext<DataType>(x));
				}
			}
			return m_Contexts[depth];
		}

		public void Update()
		{
			m_Executing = true;
			while(!Paused)
			{
				ActionContext<DataType> currentContext = GetContext(m_CurrentContext);
				while(currentContext.Count == 0 && m_CurrentContext > 0)
				{
					m_CurrentContext--;
					currentContext = GetContext(m_CurrentContext);
				}
				if(m_CurrentContext == 0 && currentContext.Count == 0)
				{	
					break;
				}
				if(currentContext.Execute(m_Data))
				{
					m_CurrentContext++;
				}
			}
			m_Executing = false;
		}

		public bool HasPendingActions()
		{
			for(int x = 0; x < m_Contexts.Count; x++)
			{
				if(m_Contexts[x].Count > 0)
				{
					return true;
				}
			}
			return false;
		}

		public void Pause(bool enable)
		{
			m_Paused = enable;
		}
	}
}
