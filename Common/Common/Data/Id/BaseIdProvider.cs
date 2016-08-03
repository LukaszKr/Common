namespace Common.Data
{
	public abstract class BaseIdProvider
    {
		public abstract int GetId();
		public virtual void ReleaseId(int id) { }
    }
}
