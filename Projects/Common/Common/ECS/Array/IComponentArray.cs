namespace ProceduralLevel.ECS
{
	public interface IComponentArray
	{
		void SetID(ComponentID id);
		ComponentID GetID();

		void Create();
		void Remove(int index);
		void Resize(int newSize);
	}
}
