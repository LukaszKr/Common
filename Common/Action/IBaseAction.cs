namespace ProceduralLevel.Common.Action
{
	public interface IBaseAction<DataType>
	{
        int ExecutionTick { get; set; }

		void Apply(DataType data);
		bool IsValid(DataType data);
	}
}
