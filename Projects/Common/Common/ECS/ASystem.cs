using ProceduralLevel.Common.Data;
using System.Collections.Generic;

namespace ProceduralLevel.ECS
{
	public abstract class ASystem
	{
		public readonly EntityManager EntityManager;
		public readonly BitMask ComponentMask;
		
		protected List<Entity> m_ValidEntities = new List<Entity>();

		public ASystem(EntityManager entityManager)
		{
			EntityManager = entityManager;
			ComponentMask = new BitMask(entityManager.MaxComponentID);
		}

		public void ValidateEntity(Entity entity)
		{
			if(entity.ComponentMask.Contains(ComponentMask))
			{
				int index = m_ValidEntities.IndexOf(entity);
				if(index < 0)
				{
					m_ValidEntities.Add(entity);
				}
			}
			else
			{
				m_ValidEntities.Remove(entity);
			}
		}

		public void RemoveEntity(Entity entity)
		{
			m_ValidEntities.Remove(entity);
		}

		public void RemoveAllEntities()
		{
			m_ValidEntities.Clear();
		}
	}
}
