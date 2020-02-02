using System.Collections.Generic;

namespace ProceduralLevel.Common.Tween
{
	public sealed class TweenerManager
	{
		public static TweenerManager Instance = new TweenerManager();

		private readonly List<ATweener> m_Active = new List<ATweener>();

		private TweenerManager()
		{

		}

		public void Update(float deltaTime)
		{
			int count = m_Active.Count;
			for(int x = 0; x < count; ++x)
			{
				ATweener animator = m_Active[x];
				TweenProgress progress = animator.Update(deltaTime);
				if(progress.Finished)
				{
					m_Active.RemoveAt(x);
					--x;
					--count;
				}
			}
		}

		public void Push(ATweener animator)
		{
			m_Active.Add(animator);
		}
	}
}
