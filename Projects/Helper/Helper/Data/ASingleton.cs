namespace ProceduralLevel.Common.Helper
{
	public abstract class ASingleton<TType> where TType: class, new()
	{
		public readonly TType Instance = new TType();

		protected ASingleton()
		{

		}
	}
}
