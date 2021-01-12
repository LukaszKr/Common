using System;
using System.Collections.Generic;
using ProceduralLevel.Common.Event;

namespace ProceduralLevel.Common.Tween
{
	public abstract class AGroupTween: ITween
	{
		protected readonly List<ITween> m_Tweens = new List<ITween>();

		private readonly TweenUpdater m_Manager;
		private readonly AGroupTween m_Parent;

		public readonly CustomEvent OnFinished = new CustomEvent();

		public bool IsActive { get { return m_Tweens.Count > 0; } }

		public float Speed = 1.0f;

		public AGroupTween(AGroupTween parent)
		{
			m_Manager = parent.m_Manager;
			m_Parent = parent;
		}

		public AGroupTween(TweenUpdater manager)
		{
			m_Manager = manager;
		}

		public AGroupTween Add(ITween tween)
		{
			m_Tweens.Add(tween);
			if(m_Parent == null && m_Tweens.Count == 1)
			{
				m_Manager.Push(this);
			}
			return this;
		}

		public TweenProgress Update(float deltaTime)
		{
			if(m_Tweens.Count > 0)
			{
				TweenProgress progress = OnUpdate(deltaTime*Speed);
				if(progress.Finished)
				{
					if(m_Tweens.Count > 0)
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

		public void Cancel(ITween tween)
		{
			int count = m_Tweens.Count;
			for(int x = 0; x < count; ++x)
			{
				ITween existingTween = m_Tweens[x];
				if(existingTween == tween)
				{
					existingTween.Cancel();
					m_Tweens.RemoveAt(x);
					break;
				}
			}
		}

		public virtual void Cancel()
		{
			int count = m_Tweens.Count;
			for(int x = 0; x < count; ++x)
			{
				ITween tween = m_Tweens[x];
				tween.Cancel();
			}
			m_Tweens.Clear();
		}

		protected abstract TweenProgress OnUpdate(float deltaTime);

		#region Grouping
		public LinearGroupTween Linear()
		{
			LinearGroupTween tweener = new LinearGroupTween(this);
			Add(tweener);
			return tweener;
		}

		public ParallelGroupTween Parallel()
		{
			ParallelGroupTween tweener = new ParallelGroupTween(this);
			Add(tweener);
			return tweener;
		}

		public AGroupTween EndGroup()
		{
			return m_Parent;
		}
		#endregion
	}
}
