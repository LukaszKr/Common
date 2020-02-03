using ProceduralLevel.Common.Event;

namespace ProceduralLevel.Common.SourceListener
{
	public class SourceListenerEntry<TSource>
		where TSource : class
	{
		public readonly ISourceListener<TSource> Listener;
		private readonly EventBinder m_EventBinder = new EventBinder();

		public SourceListenerEntry(ISourceListener<TSource> listener)
		{
			Listener = listener;
		}

		public void AttachToSource(TSource source)
		{
			Listener.AttachToSource(source, m_EventBinder);
		}

		public void DetachFromSource(TSource source)
		{
			m_EventBinder.UnbindAll();
			Listener.DetachFromSource(source);
		}

		public override string ToString()
		{
			return Listener.ToString();
		}
	}
}
