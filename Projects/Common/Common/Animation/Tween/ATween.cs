using ProceduralLevel.Common.Event;
using System;

namespace ProceduralLevel.Common.Animation
{
	public abstract class ATween: ITween
	{
		private ETweenState m_State;

		public ETweenState State { get { return m_State; } }

		public readonly CustomEvent OnFinish = new CustomEvent();

		public bool IsFinished { get { return m_State == ETweenState.Finished; } }

		public ATween()
		{
			m_State = ETweenState.Pending;
		}

		public TweenProgress Update(float deltaTime)
		{
			if(m_State == ETweenState.Pending)
			{
				SetStarted();
			}

			if(m_State == ETweenState.Started)
			{
				TweenProgress progress = OnUpdate(deltaTime);
				if(progress.Finished)
				{
					SetFinished();
				}
				return progress;
			}
			throw new InvalidOperationException();
		}

		public virtual void Cancel()
		{
			OnFinish.RemoveAllListeners();
		}

		protected void SetStarted()
		{
			m_State = ETweenState.Started;
			Start();
		}

		protected void SetFinished()
		{
			m_State = ETweenState.Finished;
			Finish();
			OnFinish.Invoke();
			OnFinish.RemoveAllListeners();
		}

		protected abstract void Start();
		protected abstract TweenProgress OnUpdate(float deltaTime);
		protected abstract void Finish();
	}
}
