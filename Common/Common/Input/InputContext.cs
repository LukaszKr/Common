using System.Collections.Generic;

namespace Common.Input
{
	public class InputContext<InputType>
	{
		public int ContextID { get; private set; }

		private List<InputType> m_Input = new List<InputType>();

		public List<InputType> Input
		{
			get { return m_Input; }
		}

		public InputContext(int contextID, params InputType[] input)
		{
			ContextID = contextID;
			m_Input.AddRange(input);
		}

		public bool IsInputValid(InputType input)
		{
			return m_Input.Contains(input);
		}
	}
}
