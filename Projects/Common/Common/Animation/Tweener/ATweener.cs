using ProceduralLevel.Common.Event;
using System;
using System.Collections.Generic;

namespace ProceduralLevel.Common.Animation
{
	public abstract class ATweener: ITween
	{
		protected readonly List<ITween> m_Animations = new List<ITween>();

		private readonly TweenerManager m_Manager;
		private readonly ATweener m_Parent;

		public readonly CustomEvent OnFinished = new CustomEvent();

		public bool IsActive { get { return m_Animations.Count > 0; } }

		public float Speed = 1.0f;

		public ATweener(ATweener parent)
		{
			m_Manager = TweenerManager.Instance;
			m_Parent = parent;
		}

		public ATweener Add(ITween animation)
		{
			m_Animations.Add(animation);
			if(m_Parent == null && m_Animations.Count == 1)
			{
				m_Manager.Push(this);
			}
			return this;
		}

		public TweenProgress Update(float deltaTime)
		{
			if(m_Animations.Count > 0)
			{
				TweenProgress progress = OnUpdate(deltaTime*Speed);
				if(progress.Finished)
				{
					if(m_Animations.Count > 0)
					{
						throw new Exception();
					}
				}
				if(progress.Finished)
				{
					OnFinished.Invoke();
				}
				return progress;
			}
			return new TweenProgress(true, 0f);
		}

		public void Cancel(ITween animation)
		{
			int count = m_Animations.Count;
			for(int x = 0; x < count; ++x)
			{
				ITween existingAnimation = m_Animations[x];
				if(existingAnimation == animation)
				{
					existingAnimation.Cancel();
					m_Animations.RemoveAt(x);
					break;
				}
			}
		}

		public virtual void Cancel()
		{
			int count = m_Animations.Count;
			for(int x = 0; x < count; ++x)
			{
				ITween animation = m_Animations[x];
				animation.Cancel();
			}
			m_Animations.Clear();
		}

		protected abstract TweenProgress OnUpdate(float deltaTime);

		#region Grouping
		public LinearTweener Linear()
		{
			LinearTweener animator = new LinearTweener(this);
			Add(animator);
			return animator;
		}

		public ParallelTweener Parallel()
		{
			ParallelTweener animator = new ParallelTweener(this);
			Add(animator);
			return animator;
		}

		public ATweener EndGroup()
		{
			return m_Parent;
		}
		#endregion
	}
}
