namespace Common.State
{
	public class StateChangedEvent<StateIDType>
	{
		public BaseState<StateIDType> OldState;
		public BaseState<StateIDType> NewState;

		public StateChangedEvent(BaseState<StateIDType> oldState, BaseState<StateIDType> newState)
		{
			OldState = oldState;
			NewState = newState;
		}
	}
}
