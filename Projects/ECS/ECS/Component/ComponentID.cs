namespace ProceduralLevel.ECS
{
	public struct ComponentID
	{
		public const int INT_SIZE = 32;

		public int Index;
		public int Offset;

		public ComponentID(int id)
		{
			Index = id/INT_SIZE;
			Offset = id % INT_SIZE;
		}
	}
}
