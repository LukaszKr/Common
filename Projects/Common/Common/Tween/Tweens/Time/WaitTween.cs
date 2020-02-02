namespace ProceduralLevel.Common.Tween
{
	public sealed class WaitTween: ATween
	{
		private readonly float m_Duration;
		private float m_Elapsed = 0;

		public WaitTween(float duration)
		{
			m_Duration = duration;
		}

		protected override void Start()
		{
		}

		protected override void Finish()
		{
		}

		protected override TweenProgress OnUpdate(float deltaTime)
		{
			float newElapsed = m_Elapsed+deltaTime;
			if(newElapsed >= m_Duration)
			{
				float notUsed = newElapsed-m_Duration;
				return new TweenProgress(true, deltaTime-notUsed);
			}
			else
			{
				m_Elapsed = newElapsed;
				return new TweenProgress(false, deltaTime);
			}
		}
	}
}
