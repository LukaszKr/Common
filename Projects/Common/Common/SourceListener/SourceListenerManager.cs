using System;
using System.Collections.Generic;

namespace ProceduralLevel.Common.SourceListener
{
	public class SourceListenerManager<TSource>
		where TSource : class
	{
		private readonly List<SourceListenerEntry<TSource>> m_Listeners = new List<SourceListenerEntry<TSource>>();
		protected TSource m_CurrentSource;
		private bool m_Active = false;

		private bool IsActiveAndEnabled { get { return m_Active && m_CurrentSource != null; } }

		public void SetSource(TSource source)
		{
			if(IsActiveAndEnabled)
			{
				DetachFromCurrent();
			}

			m_CurrentSource = source;
			if(IsActiveAndEnabled)
			{
				AttachToCurrent();
			}
		}

		public void Add(ISourceListener<TSource> listener)
		{
			if(GetEntry(listener) != null)
			{
				throw new ArgumentException();
			}

			SourceListenerEntry<TSource> entry = new SourceListenerEntry<TSource>(listener);
			m_Listeners.Add(entry);
			if(IsActiveAndEnabled)
			{
				entry.AttachToSource(m_CurrentSource);
			}
		}

		public void Remove(ISourceListener<TSource> listener)
		{
			SourceListenerEntry<TSource> entry = GetEntry(listener);
			if(entry == null)
			{
				throw new ArgumentException();
			}

			if(IsActiveAndEnabled)
			{
				entry.DetachFromSource();
			}
			m_Listeners.Remove(entry);
		}

		private SourceListenerEntry<TSource> GetEntry(ISourceListener<TSource> listener)
		{
			int count = m_Listeners.Count;
			for(int x = 0; x < count; ++x)
			{
				SourceListenerEntry<TSource> entry = m_Listeners[x];
				if(entry.Listener == listener)
				{
					return entry;
				}
			}
			return null;
		}

		private void AttachToCurrent()
		{
			for(int x = 0; x < m_Listeners.Count; ++x)
			{
				SourceListenerEntry<TSource> listener = m_Listeners[x];
				listener.AttachToSource(m_CurrentSource);
			}
		}

		private void DetachFromCurrent()
		{
			for(int x = 0; x < m_Listeners.Count; ++x)
			{
				SourceListenerEntry<TSource> listener = m_Listeners[x];
				listener.DetachFromSource();
			}
		}

		public void SetActive(bool active)
		{
			if(m_Active != active)
			{
				m_Active = active;
				if(IsActiveAndEnabled)
				{
					AttachToCurrent();
				}
				else if(m_CurrentSource != null)
				{
					DetachFromCurrent();
				}
			}
		}
	}
}
