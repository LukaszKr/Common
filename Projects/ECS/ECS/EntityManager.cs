using System.Collections.Generic;

namespace ProceduralLevel.ECS
{
	public class EntityManager
	{
		public readonly int MaxComponentID;

		public GenericArray<Entity> Entities;
		private List<ASystem> m_Systems = new List<ASystem>();
		public ComponentArray<MaskComponent> Mask = new ComponentArray<MaskComponent>(); 

		private IComponentArray[] m_DataArrays;

		public EntityManager(int maxEntityCount)
		{
			Entities = new GenericArray<Entity>();
			m_DataArrays = ComponentArrayHelper.FindComponentArrays(this);
			for(int x = 0; x < m_DataArrays.Length; ++x)
			{
				m_DataArrays[x].SetID(new ComponentID(x));
			}

			MaxComponentID = m_DataArrays.Length+1;
			SetEntityLimit(maxEntityCount);
		}

		public void Update()
		{
			int count = m_Systems.Count;
			for(int x = 0; x < count; ++x)
			{
				m_Systems[x].Update();
			}
		}

		public void RegisterSystem(ASystem system)
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
