using ProceduralLevel.Common.Event;

namespace ProceduralLevel.Common.SourceListener
{
	public interface ISourceListener<TSource>
		where TSource : class
	{
		void AttachToSource(TSource source, EventBinder binder);
		void DetachFromSource(TSource source);
	}
}
