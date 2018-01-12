using System;

namespace ProceduralLevel.Common.ECS
{
	public interface IComponentArray
	{
		void SetID(ComponentID id);
		ComponentID GetID();

		void Create();
		void Remove(int index);
		void Resize(int newSize);

		Type GetComponentType();
	}
}
