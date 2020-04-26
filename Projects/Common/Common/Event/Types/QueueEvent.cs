﻿namespace ProceduralLevel.Common.Event
{
	public class QueueEvent: AEvent
	{
		public override void Invoke()
		{
			int count = m_Listeners.Count;
			if(count > 0)
			{
				m_Listeners[0]();
			}
		}
	}

	public class QueueEvent<T0>: AEvent<T0>
	{
		public override void Invoke(T0 arg0)
		{
			int count = m_Listeners.Count;
			if(count > 0)
			{
				m_Listeners[0](arg0);
			}
		}
	}

	public class QueueEvent<T0, T1>: AEvent<T0, T1>
	{
		public override void Invoke(T0 arg0, T1 arg1)
		{
			int count = m_Listeners.Count;
			if(count > 0)
			{
				m_Listeners[0](arg0, arg1);
			}
		}
	}

	public class QueueEvent<T0, T1, T2>: AEvent<T0, T1, T2>
	{
		public override void Invoke(T0 arg0, T1 arg1, T2 arg2)
		{
			int count = m_Listeners.Count;
			if(count > 0)
			{
				m_Listeners[0](arg0, arg1, arg2);
			}
		}
	}

	public class QueueEvent<T0, T1, T2, T3>: AEvent<T0, T1, T2, T3>
	{
		public override void Invoke(T0 arg0, T1 arg1, T2 arg2, T3 arg3)
		{
			int count = m_Listeners.Count;
			if(count > 0)
			{
				m_Listeners[0](arg0, arg1, arg2, arg3);
			}
		}
	}

}
