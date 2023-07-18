using System.Collections.Generic;

namespace ProceduralLevel.Common.Tween
{
	public sealed class TweenUpdater
	{
		public static readonly TweenUpdater Default = new TweenUpdater();

		private readonly List<ITween> m_Active = new List<ITween>();

		public TweenUpdater()
		{

		}

		public void Update(float deltaTime)
		{
			int count = m_Active.Count;
			for(int x = 0; x < count; ++x)
			{
				ITween tween = m_Active[x];
				TweenProgress progress = tween.Update(deltaTime);
				if(progress.Finished)
				{
					m_Active.RemoveAt(x);
					--x;
					--count;
				}
			}
		}

		public void Push(ITween tween)
		{
			m_Active.Add(tween);
		}
	}
}
