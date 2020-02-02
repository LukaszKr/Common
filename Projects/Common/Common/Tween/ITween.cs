namespace ProceduralLevel.Common.Tween
{
	public interface ITween
	{
		TweenProgress Update(float deltaTime);
		void Cancel();
	}
}
