namespace ProceduralLevel.ECS
{
	public abstract class ASystem<TEntityManager>: ISystem
		where TEntityManager: AEntityManager
	{
		public MaskComponent Mask = new MaskComponent();
		private IComponentArray[] m_DataArrays;


		public ASystem(TEntityManager entityManager)
		{
			m_DataArrays = ComponentArrayHelper.FindComponentArrays(this);
			for(int x = 0; x < m_DataArrays.Length; ++x)
			{
				Mask.Set(m_DataArrays[x].GetID());
			}
		}

		public void Update()
		{
			OnUpdate();
		}

		protected abstract void OnUpdate();
	}
}
