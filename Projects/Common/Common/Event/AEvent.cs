using System.Collections.Generic;

namespace ProceduralLevel.Common.Event
{
	public abstract class AEvent
	{
		public delegate void Callback();

		protected List<Callback> m_Listeners = new List<Callback>();

		public abstract void Invoke();

		public void AddListener(Callback listener)
		{
			m_Listeners.Add(listener);
		}

		public bool RemoveListener(Callback listener)
		{
			return m_Listeners.Remove(listener);
		}

		public void RemoveAllListeners()
		{
			m_Listeners.Clear();
		}

		public override string ToString()
		{
			return string.Format("[Event, ListenerCount: {0}, Types: ]", 
				 m_Listeners.Count);
		}
	}

	public abstract class AEvent<T0>
	{
		public delegate void Callback(T0 arg0);

		protected List<Callback> m_Listeners = new List<Callback>();

		public abstract void Invoke(T0 arg0);

		public void AddListener(Callback listener)
		{
			m_Listeners.Add(listener);
		}

		public bool RemoveListener(Callback listener)
		{
			return m_Listeners.Remove(listener);
		}

		public void RemoveAllListeners()
		{
			m_Listeners.Clear();
		}

		public override string ToString()
		{
			return string.Format("[Event, ListenerCount: {1}, Types: {0}]", 
				typeof(T0).Name,  m_Listeners.Count);
		}
	}

	public abstract class AEvent<T0, T1>
	{
		public delegate void Callback(T0 arg0, T1 arg1);

		protected List<Callback> m_Listeners = new List<Callback>();

		public abstract void Invoke(T0 arg0, T1 arg1);

		public void AddListener(Callback listener)
		{
			m_Listeners.Add(listener);
		}

		public bool RemoveListener(Callback listener)
		{
			return m_Listeners.Remove(listener);
		}

		public void RemoveAllListeners()
		{
			m_Listeners.Clear();
		}

		public override string ToString()
		{
			return string.Format("[Event, ListenerCount: {2}, Types: {0}, {1}]", 
				typeof(T0).Name, typeof(T1).Name,  m_Listeners.Count);
		}
	}

	public abstract class AEvent<T0, T1, T2>
	{
		public delegate void Callback(T0 arg0, T1 arg1, T2 arg2);

		protected List<Callback> m_Listeners = new List<Callback>();

		public abstract void Invoke(T0 arg0, T1 arg1, T2 arg2);

		public void AddListener(Callback listener)
		{
			m_Listeners.Add(listener);
		}

		public bool RemoveListener(Callback listener)
		{
			return m_Listeners.Remove(listener);
		}

		public void RemoveAllListeners()
		{
			m_Listeners.Clear();
		}

		public override string ToString()
		{
			return string.Format("[Event, ListenerCount: {3}, Types: {0}, {1}, {2}]", 
				typeof(T0).Name, typeof(T1).Name, typeof(T2).Name,  m_Listeners.Count);
		}
	}

	public abstract class AEvent<T0, T1, T2, T3>
	{
		public delegate void Callback(T0 arg0, T1 arg1, T2 arg2, T3 arg3);

		protected List<Callback> m_Listeners = new List<Callback>();

		public abstract void Invoke(T0 arg0, T1 arg1, T2 arg2, T3 arg3);

		public void AddListener(Callback listener)
		{
			m_Listeners.Add(listener);
		}

		public bool RemoveListener(Callback listener)
		{
			return m_Listeners.Remove(listener);
		}

		public void RemoveAllListeners()
		{
			m_Listeners.Clear();
		}

		public override string ToString()
		{
			return string.Format("[Event, ListenerCount: {4}, Types: {0}, {1}, {2}, {3}]", 
				typeof(T0).Name, typeof(T1).Name, typeof(T2).Name, typeof(T3).Name,  m_Listeners.Count);
		}
	}

}
