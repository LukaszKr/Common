using System.Collections.Generic;

namespace ProceduralLevel.ECS
{
	public abstract class AEntityManager
	{
		public readonly int MaxComponentID;

		public DataArray<Entity> Entities;
		private List<ISystem> m_Systems = new List<ISystem>();
		public ComponentArray<MaskComponent> Mask = new ComponentArray<MaskComponent>(); 

		private IComponentArray[] m_DataArrays;

		public AEntityManager(int maxEntityCount)
		{
			Entities = new DataArray<Entity>();
			m_DataArrays = ComponentArrayHelper.FindComponentArrays(this);
			for(int x = 0; x < m_DataArrays.Length; ++x)
			{
				m_DataArrays[x].SetID(new ComponentID(x));
			}

			MaxComponentID = m_DataArrays.Length+1;
			SetEntityLimit(maxEntityCount);
		}

		public void RegisterSystem(ISystem system)
		{
			m_Systems.Add(system);
			ComponentArrayHelper.MapArrays(m_DataArrays, system);
		}

		public void SetEntityLimit(int newSize)
		{
			Entities.Resize(newSize);
			for(int x = 0; x < m_DataArrays.Length; ++x)
			{
				m_DataArrays[x].Resize(newSize);
			}
		}

		public Entity CreateEntity()
		{
			int index = Entities.Count;
			Entity entity = new Entity(this, index);
			Entities.Add(entity);
			for(int x = 0; x < m_DataArrays.Length; ++x)
			{
				m_DataArrays[x].Create();
			}
			entity.AddComponent(new MaskComponent(), Mask);
			return entity;
		}

		public void DestroyEntity(Entity entity)
		{
			int index = entity.Index;
			entity.Index = -1;
			Entities.Remove(index);
			Entities.Data[index].Index = index;
			for(int x = 0; x < m_DataArrays.Length; ++x)
			{
				m_DataArrays[x].Remove(index);
			}
		}
	}
}
