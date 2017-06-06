using System.Collections.Generic;

namespace ProceduralLevel.Common.State
{
	public abstract class AFiniteStateMachine<StateIDType>
	{
		private BaseState<StateIDType> m_CurrentState;

		private Dictionary<StateIDType, BaseState<StateIDType>> m_States = new Dictionary<StateIDType, BaseState<StateIDType>>();

		public BaseState<StateIDType> CurrentState
		{
			get { return m_CurrentState; }
		}

		public AFiniteStateMachine()
		{
		}

		public void Update()
		{
			if(m_CurrentState != null)
			{
				m_CurrentState.Update();
			}
		}

		#region State
		public bool RegisterState(BaseState<StateIDType> state)
		{
			if(m_States.ContainsKey(state.StateID))
			{
				return false;
			}
			m_States[state.StateID] = state;
			return true;
		}

		public bool SetState(StateIDType stateId, bool silient = false)
		{
			BaseState<StateIDType> newState;
			if(!m_States.TryGetValue(stateId, out newState))
			{
				return false;
			}
			if(m_CurrentState != null)
			{
				m_CurrentState.Leave();
			}
			BaseState<StateIDType> oldState = m_CurrentState;
			m_CurrentState = newState;
			OnStateChanged(oldState, newState);
			if(!silient)
			{
				m_CurrentState.Enter();
			}
			return true;
		}

		public BaseState<StateIDType> GetState(StateIDType stateId)
		{
			BaseState<StateIDType> state;
			m_States.TryGetValue(stateId, out state);
			return state;
		}

		public StateType GetState<StateType>(StateIDType stateId) where StateType: BaseState<StateIDType>
		{
			BaseState<StateIDType> state;
			m_States.TryGetValue(stateId, out state);
			return state as StateType;
		}

		protected abstract void OnStateChanged(BaseState<StateIDType> oldState, BaseState<StateIDType> newState);
		#endregion
	}
}

