namespace ProceduralLevel.Common.Pooling
{
	public interface IPoolEntry
	{
		void OnGetFromPool();
		void OnReturnToPool();
	}
}
