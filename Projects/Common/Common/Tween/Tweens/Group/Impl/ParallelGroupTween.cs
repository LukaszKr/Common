using System;

namespace ProceduralLevel.Common.Tween
{
	public sealed class ParallelGroupTween : AGroupTween
	{
		public ParallelGroupTween(AGroupTween parent)
			: base(parent)
		{
		}

		public ParallelGroupTween(TweenUpdater manager = null)
			: base(manager)
		{
		}

		protected override TweenProgress OnUpdate(float deltaTime)
		{
			TweenProgress result = new TweenProgress(true, 0f);
			int count = m_Tweens.Count;
			for(int x = count-1; x >= 0; --x)
			{
				ITween tween = m_Tweens[x];
				TweenProgress progress = tween.Update(deltaTime);
				if(progress.Finished)
				{
					m_Tweens.RemoveAt(x);
					result = new TweenProgress(m_Tweens.Count == 0, deltaTime);
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
