using System;

namespace ProceduralLevel.Common.Event
{
    public partial class EventBinder
    {
		public void Bind<T0>(Event<T0> evt, Action<T0> callback)
		{
			AddBinding(new EventBinding<T0>(evt, callback));
		}
		public void Bind<T0, T1>(Event<T0, T1> evt, Action<T0, T1> callback)
		{
			AddBinding(new EventBinding<T0, T1>(evt, callback));
		}
		public void Bind<T0, T1, T2>(Event<T0, T1, T2> evt, Action<T0, T1, T2> callback)
		{
			AddBinding(new EventBinding<T0, T1, T2>(evt, callback));
		}
		public void Bind<T0, T1, T2, T3>(Event<T0, T1, T2, T3> evt, Action<T0, T1, T2, T3> callback)
		{
			AddBinding(new EventBinding<T0, T1, T2, T3>(evt, callback));
		}
    }
}
