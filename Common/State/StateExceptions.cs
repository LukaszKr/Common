using System;

namespace ProceduralLevel.Common.State
{
	public class IllegalTransitionException<StateIdType>: Exception
	{
		public IllegalTransitionException(StateIdType from, StateIdType to)
			: base(string.Format("Transition from {0} to {1} is illegal", from.ToString(), to.ToString()))
		{

		}
	}
}
