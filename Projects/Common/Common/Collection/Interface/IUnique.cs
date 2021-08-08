namespace ProceduralLevel.Common.Collection
{
	public interface IUnique<TUnique>
		where TUnique : class
	{
		UID<TUnique> GetID();
	}
}
