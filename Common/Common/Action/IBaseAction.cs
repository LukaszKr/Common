namespace ProceduralLevel.Common.Action
{
	public interface IBaseAction<DataType>
	{
		void Apply(DataType data);
		bool IsValid(DataType data);
	}
}
