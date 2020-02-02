namespace ProceduralLevel.Common.Tween
{
	public struct TweenProgress
	{
		public readonly bool Finished;
		public readonly float UsedTime;

		public TweenProgress(bool finished, float usedTime)
		{
			Finished = finished;
			UsedTime = usedTime;
		}

		public override string ToString()
		{
			return string.Format("[Finished: {0}, UsedTime: {1}]", Finished, UsedTime);
		}
	}
}
