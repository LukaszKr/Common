namespace ProceduralLevel.Common.Action
{
	public interface IAction<DataType>
	{
		void Apply(DataType data);
		bool IsValid(DataType data);
	}
}
