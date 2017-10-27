using ProceduralLevel.Common.Data;

namespace ProceduralLevel.ECS
{
	public class Entity
	{
		public readonly EntityManager EntityManager;
		public readonly int ID;
		public readonly AComponent[] Components;
		public readonly BitMask ComponentMask;

		public bool IsActive;
		public bool IsDirty;

		public Entity(EntityManager entityManager, int id)
		{
			EntityManager = entityManager;
			Components = new AComponent[entityManager.MaxComponentID];
			ComponentMask = new BitMask(Components.Length);
		}

		public AComponent GetComponent(int id)
		{
			return Components[id];
		}

		public ComponentType GetComponent<ComponentType>(int id)
			where ComponentType: AComponent
		{
			return Components[id] as ComponentType;
		}

		public void ReplaceComponent(AComponent component)
		{
			Components[component.ID] = component;
			ComponentMask.SetBit(component.ID);
			EntityManager.MarkEntityAsDirty(this);
		}

		public bool AddComponent(AComponent component)
		{
			if(!ComponentMask.HasBit(component.ID))
			{
				Components[component.ID] = component;
				ComponentMask.SetBit(component.ID);
				EntityManager.MarkEntityAsDirty(this);
				return true;
			}
			return false;
		}

		public void RemoveComponent(int id)
		{
			if(ComponentMask.HasBit(id))
			{
				ComponentMask.UnsetBit(id);
				Components[id] = null;
				EntityManager.MarkEntityAsDirty(this);
			}
		}

		public void Clear()
		{
			for(int x = 0; x < Components.Length; ++x)
			{
				Components[x] = null;
			}
		}
	}
}
