namespace ProceduralLevel.Common.Command
{
    public class BulkCommand<DataType>: ICommand<DataType>
    {
		private ICommand<DataType>[] m_Commands;

		public BulkCommand(params ICommand<DataType>[] commands)
		{
			m_Commands = commands;
		}

		public void Do(DataType data)
		{
			for(int x = 0; x < m_Commands.Length; x++)
			{
				m_Commands[x].Do(data);
			}
		}

		public void Undo(DataType data)
		{
			for(int x = m_Commands.Length - 1; x >= 0; x--)
			{
				m_Commands[x].Undo(data);
			}
		}
	}
}
