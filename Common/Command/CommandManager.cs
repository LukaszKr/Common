using System.Collections.Generic;

namespace ProceduralLevel.Common.Command
{
	public class CommandManager<DataType>
	{
		private List<ICommand<DataType>> m_Commands = new List<ICommand<DataType>>();
		private int m_Header = 0;
        private DataType m_Data;

		public int Count
		{
			get { return m_Header; }
		}

		public CommandManager(DataType data)
		{
            m_Data = data;
		}

		public void ExecuteCommand(ICommand<DataType> command)
		{
			command.Do(m_Data);
			if(m_Header >= m_Commands.Count)
			{
				m_Commands.Add(command);
			}
			else
			{
				m_Commands[m_Header] = command;
			}
			m_Header++;
		}

		public bool UndoCommand()
		{
			if(m_Header > 0)
			{
				m_Header--;
				m_Commands[m_Header].Undo(m_Data);
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool RedoCommand()
		{
			if(m_Header <= m_Commands.Count)
			{
				ICommand<DataType> command = m_Commands[m_Header-1];
				if(command != null)
				{
					command.Do(m_Data);
					m_Header++;
					return true;
				}
			}
			return false;
		}
	}
}
