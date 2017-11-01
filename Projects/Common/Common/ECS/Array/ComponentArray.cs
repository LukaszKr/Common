namespace ProceduralLevel.ECS
{
	public class ComponentArray<DataType>: DataArray<DataType>, IComponentArray
		where DataType : struct, IComponent
	{
		public ComponentID ID;

		public void SetID(ComponentID id)
		{
			ID = id;
		}

		public ComponentID GetID()
		{
			return ID;
		}

		public void Create()
		{
			Add(default(DataType));
		}
	}
}
