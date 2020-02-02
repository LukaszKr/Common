namespace ProceduralLevel.Common.Easing
{
	public struct EasingFunc
	{
		public readonly float Duration;
		private readonly EasingHelper.EasingDelegate m_Method;

		public EasingFunc(float duration, EEasingMethod method = EEasingMethod.Sine, EEasingType type = EEasingType.In)
		{
			m_Method = EasingHelper.Get(method, type);
			Duration = duration;
		}

		public float CalculateProgress(float elapsed)
		{
			return m_Method(elapsed/Duration);
		}

		public override string ToString()
		{
			return string.Format("[Duration: {0}]",
				Duration.ToString());
		}
	}
}
