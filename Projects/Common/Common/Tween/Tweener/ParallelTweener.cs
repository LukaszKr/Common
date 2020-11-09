using System;

namespace ProceduralLevel.Common.Tween
{
	public sealed class ParallelTweener: ATweener
	{
		public ParallelTweener(ATweener parent = null)
			: base(parent)
		{
		}

		protected override TweenProgress OnUpdate(float deltaTime)
		{
			TweenProgress result = new TweenProgress(true, 0f);
			int count = m_Animations.Count;
			for(int x = count-1; x >= 0; --x)
			{
				ITween animation = m_Animations[x];
				TweenProgress progress = animation.Update(deltaTime);
				if(progress.Finished)
				{
					m_Animations.RemoveAt(x);
					result = new TweenProgress(m_Animations.Count == 0, deltaTime);
				}
				else
				{
					result = new TweenProgress(false, Math.Max(result.UsedTime, progress.UsedTime));
				}
			}
			return result;
		}
	}
}
