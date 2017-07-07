using System;
using System.Collections.Generic;

namespace ProceduralLevel.Common.Event
{
	public class Event<T0>
	{
		protected List<Action<T0>> m_Listeners = new List<Action<T0>>();

		public override string ToString()
		{
			return string.Format("[EventChannel, ListenerCount: {1}, Types: {0}]", 
				typeof(T0).Name, m_Listeners.Count);
		}

		public void Invoke(T0 arg0)
		{
			for(int x = m_Listeners.Count-1; x >= 0; x--)
			{
				m_Listeners[x](arg0);
			}
		}

		public void AddListener(Action<T0> listener)
		{
			m_Listeners.Add(listener);
		}

		public bool RemoveListener(Action<T0> listener)
		{
			return m_Listeners.Remove(listener);
		}

		public void RemoveAllListeners()
		{
			m_Listeners.Clear();
		}
	}

	public class Event<T0, T1>
	{
		protected List<Action<T0, T1>> m_Listeners = new List<Action<T0, T1>>();

		public override string ToString()
		{
			return string.Format("[EventChannel, ListenerCount: {2}, Types: {0}, {1}]", 
				typeof(T0).Name, typeof(T1).Name, m_Listeners.Count);
		}

		public void Invoke(T0 arg0, T1 arg1)
		{
			for(int x = m_Listeners.Count-1; x >= 0; x--)
			{
				m_Listeners[x](arg0, arg1);
			}
		}

		public void AddListener(Action<T0, T1> listener)
		{
			m_Listeners.Add(listener);
		}

		public bool RemoveListener(Action<T0, T1> listener)
		{
			return m_Listeners.Remove(listener);
		}

		public void RemoveAllListeners()
		{
			m_Listeners.Clear();
		}
	}

	public class Event<T0, T1, T2>
	{
		protected List<Action<T0, T1, T2>> m_Listeners = new List<Action<T0, T1, T2>>();

		public override string ToString()
		{
			return string.Format("[EventChannel, ListenerCount: {3}, Types: {0}, {1}, {2}]", 
				typeof(T0).Name, typeof(T1).Name, typeof(T2).Name, m_Listeners.Count);
		}

		public void Invoke(T0 arg0, T1 arg1, T2 arg2)
		{
			for(int x = m_Listeners.Count-1; x >= 0; x--)
			{
				m_Listeners[x](arg0, arg1, arg2);
			}
		}

		public void AddListener(Action<T0, T1, T2> listener)
		{
			m_Listeners.Add(listener);
		}

		public bool RemoveListener(Action<T0, T1, T2> listener)
		{
			return m_Listeners.Remove(listener);
		}

		public void RemoveAllListeners()
		{
			m_Listeners.Clear();
		}
	}

	public class Event<T0, T1, T2, T3>
	{
		protected List<Action<T0, T1, T2, T3>> m_Listeners = new List<Action<T0, T1, T2, T3>>();

		public override string ToString()
		{
			return string.Format("[EventChannel, ListenerCount: {4}, Types: {0}, {1}, {2}, {3}]", 
				typeof(T0).Name, typeof(T1).Name, typeof(T2).Name, typeof(T3).Name, m_Listeners.Count);
		}

		public void Invoke(T0 arg0, T1 arg1, T2 arg2, T3 arg3)
		{
			for(int x = m_Listeners.Count-1; x >= 0; x--)
			{
				m_Listeners[x](arg0, arg1, arg2, arg3);
			}
		}

		public void AddListener(Action<T0, T1, T2, T3> listener)
		{
			m_Listeners.Add(listener);
		}

		public bool RemoveListener(Action<T0, T1, T2, T3> listener)
		{
			return m_Listeners.Remove(listener);
		}

		public void RemoveAllListeners()
		{
			m_Listeners.Clear();
		}
	}

}
