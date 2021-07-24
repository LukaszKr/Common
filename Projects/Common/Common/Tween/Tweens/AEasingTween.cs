using ProceduralLevel.Common.Easing;

namespace ProceduralLevel.Common.Tween
{
	public abstract class AEasingTween : ATween
	{
#if CALLSTACK_DEBUG
		public readonly string Callstack;
#endif

		private readonly EasingFunc m_Easing;

		private float m_Elapsed;
		private float m_Progress;

		public AEasingTween(EasingFunc easing)
		{
#if CALLSTACK_DEBUG
			Callstack = System.Environment.StackTrace;
#endif
			m_Easing = easing;
			m_Progress = 0;
		}

		protected override TweenProgress OnUpdate(float deltaTime)
		{
			m_Elapsed += deltaTime;
			if(m_Elapsed >= m_Easing.Duration)
			{
				float usedTime = deltaTime-(m_Elapsed-m_Easing.Duration);
				OnProgressChanged(1.0f);
				return new TweenProgress(true, usedTime);
			}
			else
			{
				m_Progress = m_Easing.CalculateProgress(m_Elapsed);
				OnProgressChanged(m_Progress);
				return new TweenProgress(false, deltaTime);
			}
		}

		protected abstract void OnProgressChanged(float progress);

		public override string ToString()
		{
			return string.Format("[{0}, {1}/{2}]",
				GetType().Name, m_Elapsed.ToString(), m_Easing.Duration.ToString());
		}
	}

	public abstract class AEasingTween<TTarget> : AEasingTween
	{
		public readonly TTarget Target;

		public AEasingTween(TTarget target, EasingFunc settings)
			: base(settings)
		{
			Target = target;
		}
	}
}
