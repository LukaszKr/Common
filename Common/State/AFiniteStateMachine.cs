using System.Collections.Generic;

namespace ProceduralLevel.Common.State
{
	public abstract class AFiniteStateMachine<StateIDType>
	{
		private bool m_UseBlacklist;

		private BaseState<StateIDType> m_CurrentState;

		private Dictionary<StateIDType, BaseState<StateIDType>> m_States = new Dictionary<StateIDType, BaseState<StateIDType>>();
		private Dictionary<StateIDType, List<StateIDType>> m_Transitions = new Dictionary<StateIDType, List<StateIDType>>();

		public BaseState<StateIDType> CurrentState
		{
			get { return m_CurrentState; }
		}

		public AFiniteStateMachine(bool useBlacklist)
		{
			m_UseBlacklist = useBlacklist;
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
			m_Transitions[state.StateID] = new List<StateIDType>();
			return true;
		}

		public bool ChangeState(StateIDType stateId)
		{
			if(CanMakeTransitionTo(stateId))
			{
				return SetState(stateId);
			}
			throw new IllegalTransitionException<StateIDType>(CurrentState.StateID, stateId);
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

		#region Transitions
		public bool AddTransition(StateIDType from, StateIDType to)
		{
			List<StateIDType> transitions = m_Transitions[from];
			if(transitions.Contains(to))
			{
				return false;
			}
			transitions.Add(to);
			return true;
		}

		public bool RemoveTransition(StateIDType from, StateIDType to)
		{
			return m_Transitions[from].Remove(to);
		}

		public bool AddTransitions(StateIDType from, params StateIDType[] to)
		{
			List<StateIDType> transitions = m_Transitions[from];
			for(int x = 0; x < to.Length; x++)
			{
				if(transitions.Contains(to[x]))
				{
					return false;
				}
			}
			transitions.AddRange(to);
			return true;
		}

		public bool RemoveTranstions(StateIDType from, params StateIDType[] to)
		{
			List<StateIDType> transitions = m_Transitions[from];
			for(int x = 0; x < to.Length; x++)
			{
				if(!transitions.Contains(to[x]))
				{
					return false;
				}
			}
			for(int x = 0; x < to.Length; x++)
			{
				transitions.Remove(to[x]);
			}
			return true;
		}

		public bool CanMakeTransitionTo(StateIDType to)
		{
			if(m_CurrentState == null)
			{
				return false;
			}
			return CanMakeTransitionTo(m_CurrentState.StateID, to);
		}

		public bool CanMakeTransitionTo(StateIDType from, StateIDType to)
		{
			if(m_UseBlacklist)
			{
				return !m_Transitions[from].Contains(to);
			}
			else
			{
				return m_Transitions[from].Contains(to);
			}
		}
		#endregion
	}
}

