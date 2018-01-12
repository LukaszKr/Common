namespace ProceduralLevel.Common.Event
{
    public partial class EventBinder
    {
		public void Bind(Event evt, Event.Callback callback)
		{
			AddBinding(new EventBinding(evt, callback));
		}
		public void Bind<T0>(Event<T0> evt, Event<T0>.Callback callback)
		{
			AddBinding(new EventBinding<T0>(evt, callback));
		}
		public void Bind<T0, T1>(Event<T0, T1> evt, Event<T0, T1>.Callback callback)
		{
			AddBinding(new EventBinding<T0, T1>(evt, callback));
		}
		public void Bind<T0, T1, T2>(Event<T0, T1, T2> evt, Event<T0, T1, T2>.Callback callback)
		{
			AddBinding(new EventBinding<T0, T1, T2>(evt, callback));
		}
		public void Bind<T0, T1, T2, T3>(Event<T0, T1, T2, T3> evt, Event<T0, T1, T2, T3>.Callback callback)
		{
			AddBinding(new EventBinding<T0, T1, T2, T3>(evt, callback));
		}
    }
}
