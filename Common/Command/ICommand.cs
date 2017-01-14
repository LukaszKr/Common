namespace ProceduralLevel.Common.Command
{
	public interface ICommand<DataType>
	{
		void Do(DataType data);
		void Undo(DataType data);
	}
}
