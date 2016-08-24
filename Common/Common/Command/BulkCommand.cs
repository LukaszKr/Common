namespace ProceduralLevel.Common.Command
{
	public class BulkCommand: ICommand
	{
		private ICommand[] m_Commands;

		public BulkCommand(params ICommand[] commands)
		{
			m_Commands = commands;
		}

		public void Do()
		{
			for(int x = 0; x < m_Commands.Length; x++)
			{
				m_Commands[x].Do();
			}
		}

		public void Undo()
		{
			for(int x = m_Commands.Length - 1; x >= 0; x--)
			{
				m_Commands[x].Undo();
			}
		}
	}
}
