namespace ProceduralLevel.Common.State
{
	public abstract class BaseState<StateIDType>
	{
		private AFiniteStateMachine<StateIDType> m_SubStateMachine;

		public AFiniteStateMachine<StateIDType> SubStateMachine
		{
			get { return m_SubStateMachine; }
		}

		public abstract StateIDType StateID
		{
			get;
		}

		public BaseState(AFiniteStateMachine<StateIDType> subStateMachine = null)
		{
			m_SubStateMachine = subStateMachine;
		}

		public void Enter()
		{
			OnEnter();

			if(m_SubStateMachine != null)
			{
				m_SubStateMachine.CurrentState.Enter();
			}
		}

		public void Update()
		{
			OnUpdate();

			if(m_SubStateMachine != null)
			{
				m_SubStateMachine.Update();
			}
		}

		public void Leave()
		{
			if(m_SubStateMachine != null)
			{
				m_SubStateMachine.CurrentState.Leave();
			}

			OnLeave();
		}

		protected abstract void OnEnter();
		protected abstract void OnUpdate();
		protected abstract void OnLeave();
	}
}
