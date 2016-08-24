using System.Collections.Generic;

namespace ProceduralLevel.Common.Command
{
	public class CommandManager
	{
		private List<ICommand> m_Commands = new List<ICommand>();
		private int m_Header = 0;

		public int Count
		{
			get { return m_Header; }
		}

		public CommandManager()
		{

		}

		public void ExecuteCommand(ICommand command)
		{
			command.Do();
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
				m_Commands[m_Header].Undo();
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
