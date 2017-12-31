namespace ProceduralLevel.ECS
{
	public abstract class ASystem
	{
		public readonly AEntityManager EntityManager;
		public MaskComponent Mask = new MaskComponent();
		private IComponentArray[] m_DataArrays;


		public ASystem(AEntityManager entityManager)
		{
			EntityManager = entityManager;
			m_DataArrays = ComponentArrayHelper.FindComponentArrays(this);
			for(int x = 0; x < m_DataArrays.Length; ++x)
			{
				Mask.Set(m_DataArrays[x].GetID());
			}
		}

		public bool IsEntityValid(Entity entity)
		{
			MaskComponent mask = EntityManager.Mask.Data[entity.Index];
			return mask.Contains(Mask);
		}

		public void Update()
		{
			OnUpdate();
		}

		protected abstract void OnUpdate();
	}
}
