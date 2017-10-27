using System;
using System.Collections.Generic;

namespace ProceduralLevel.ECS
{
	public class EntityManager
	{
		public readonly int MaxComponentID;

		private int m_NextID = -1;

		private List<ASystem> m_Systems = new List<ASystem>();
		private List<Entity> m_Entities = new List<Entity>();
		private Stack<Entity> m_Inactive = new Stack<Entity>();
		private List<Entity> m_Dirty = new List<Entity>();

		public EntityManager(int maxComponentID)
		{
			MaxComponentID = maxComponentID;
		}

		public void Update()
		{
			if(m_Dirty.Count > 0)
			{
				int dirtyCount = m_Dirty.Count;
				int systemCount = m_Systems.Count;
				for(int entIndex = 0; entIndex < dirtyCount; ++entIndex)
				{
					Entity entity = m_Dirty[entIndex];
					for(int sysIndex = 0; sysIndex < systemCount; ++sysIndex)
					{
						ASystem system = m_Systems[sysIndex];
						system.ValidateEntity(entity);
					}
				}
			}
		}

		public void RegisterSystem(ASystem system)
		{
			if(m_Systems.Contains(system))
			{
				m_Systems.Add(system);
				ValidateSystem(system);
			}
		}

		private void ValidateSystem(ASystem system)
		{
			system.RemoveAllEntities();
			int count = m_Entities.Count;
			for(int x = 0; x < count; ++x)
			{
				Entity entity = m_Entities[x];
				system.ValidateEntity(entity);
			}
		}

		#region Entity
		public Entity RequestEntity()
		{ 
			Entity entity;
			if(m_Inactive.Count > 0)
			{
				entity = m_Inactive.Pop();
			}
			else
			{
				int id = ++m_NextID;
				entity = new Entity(this, id);
				m_Entities.Add(entity);
			}
			entity.IsActive = true;
			return entity;
		}

		public void ReturnEntity(Entity entity)
		{
			if(entity.IsActive)
			{
				entity.Clear();
				entity.IsActive = false;
				m_Inactive.Push(entity);

				int count = m_Systems.Count;
				for(int x = 0; x < count; ++x)
				{
					m_Systems[x].RemoveEntity(entity);
				}
			}
			else
			{
				throw new ArgumentException();
			}
		}

		public void MarkEntityAsDirty(Entity entity)
		{
			if(!entity.IsDirty)
			{
				entity.IsDirty = true;
				m_Dirty.Add(entity);
			}
		}
		#endregion
	}
}
