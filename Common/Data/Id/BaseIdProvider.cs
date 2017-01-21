namespace ProceduralLevel.Common.Data
{
	public abstract class BaseIDProvider
    {
		public abstract int GetID();
		public virtual void ReleaseID(int ID) { }
    }
}
