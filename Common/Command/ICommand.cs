namespace ProceduralLevel.Common.Command
{
	public interface ICommand
	{
		void Do();
		void Undo();
	}
}