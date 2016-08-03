namespace Common.Action
{
	public abstract class BaseAction<DataType>
	{
		public abstract void Apply(DataType data);
		public abstract bool IsValid(DataType data);
	}
}
