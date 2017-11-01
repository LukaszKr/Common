namespace ProceduralLevel.ECS
{
	public class Entity
	{
		public readonly AEntityManager Manager;
		public int Index;

		public Entity(AEntityManager manager, int index)
		{
			Manager = manager;
			Index = index;
		}

		public bool AddComponent<TComponent>(TComponent component, ComponentArray<TComponent> components)
			where TComponent : struct, IComponent
		{
			if(Manager.Mask.Data[Index].Has(components.ID))
			{
				components.Data[Index] = component;
				return true;
			}
			return false;
		}

		public void SetComponent<TComponent>(TComponent component, ComponentArray<TComponent> components)
			where TComponent : struct, IComponent
		{
			components.Data[Index] = component;
			Manager.Mask.Data[Index].Set(components.ID);
		}

		public void RemoveComponent<TComponent>(ComponentArray<TComponent> components)
			where TComponent : struct, IComponent
		{
			components.Clear(Index);
			Manager.Mask.Data[Index].Unset(components.ID);
		}

		public override string ToString()
		{
			return string.Format("[{0}]", Index.ToString().PadLeft(5, '0'));
		}
	}
}
