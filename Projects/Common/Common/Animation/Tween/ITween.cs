namespace ProceduralLevel.Common.Animation
{
	public interface ITween
	{
		TweenProgress Update(float deltaTime);
		void Cancel();
	}
}
