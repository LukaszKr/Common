using System.Collections.Generic;

namespace ProceduralLevel.Common.Event
{
	public class CustomEvent: AEvent
	{
		public override void Invoke()
		{
			for(int x = m_Listeners.Count-1; x >= 0; x--)
			{
				m_Listeners[x]();
			}
		}
	}

	public class CustomEvent<T0>: AEvent<T0>
	{
		public override void Invoke(T0 arg0)
		{
			for(int x = m_Listeners.Count-1; x >= 0; x--)
			{
				m_Listeners[x](arg0);
			}
		}
	}

	public class CustomEvent<T0, T1>: AEvent<T0, T1>
	{
		public override void Invoke(T0 arg0, T1 arg1)
		{
			for(int x = m_Listeners.Count-1; x >= 0; x--)
			{
				m_Listeners[x](arg0, arg1);
			}
		}
	}

	public class CustomEvent<T0, T1, T2>: AEvent<T0, T1, T2>
	{
		public override void Invoke(T0 arg0, T1 arg1, T2 arg2)
		{
			for(int x = m_Listeners.Count-1; x >= 0; x--)
			{
				m_Listeners[x](arg0, arg1, arg2);
			}
		}
	}

	public class CustomEvent<T0, T1, T2, T3>: AEvent<T0, T1, T2, T3>
	{
		public override void Invoke(T0 arg0, T1 arg1, T2 arg2, T3 arg3)
		{
			for(int x = m_Listeners.Count-1; x >= 0; x--)
			{
				m_Listeners[x](arg0, arg1, arg2, arg3);
			}
		}
	}

}
