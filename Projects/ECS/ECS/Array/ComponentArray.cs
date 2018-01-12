using System;

namespace ProceduralLevel.Common.ECS
{
	public class ComponentArray<TData>: GenericArray<TData>, IComponentArray
		where TData : struct, IComponent
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
			Add(default(TData));
		}

		public Type GetComponentType()
		{
			return typeof(TData);
		}
	}
}
