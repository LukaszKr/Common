namespace ProceduralLevel.Common.Tween
{
	public sealed class LinearTweener: ATweener
	{
		private ITween m_Current;

		public LinearTweener(ATweener parent = null) 
			: base(parent)
		{
		}

		protected override TweenProgress OnUpdate(float deltaTime)
		{
			if(m_Current == null)
			{
				if(m_Animations.Count > 0)
				{
					m_Current = m_Animations[0];
				}
			}
			if(m_Current != null)
			{
				TweenProgress result = m_Current.Update(deltaTime);
				if(result.Finished)
				{
					m_Current = null;
					m_Animations.RemoveAt(0);
					if(result.UsedTime < deltaTime)
					{
						TweenProgress subResult = OnUpdate(deltaTime-result.UsedTime);
						return new TweenProgress(subResult.Finished && m_Animations.Count == 0, result.UsedTime+subResult.UsedTime);
					}
					else
					{
						return new TweenProgress(false, deltaTime);
					}
				}
				else
				{
					return new TweenProgress(false, deltaTime);
				}
			}
			return new TweenProgress(true, 0f);
		}

		public override void Cancel()
		{
			base.Cancel();
			m_Current = null;
		}

		public override string ToString()
		{
			if(m_Current != null)
			{
				return string.Format("[LinearAnimator, Current: {0}, Pending: {1}]",
					m_Current.ToString(), (m_Animations.Count-1).ToString());
			}
			else
			{
				return string.Format("[LinearAnimator, Current: N/A]");
			}
		}
	}
}
