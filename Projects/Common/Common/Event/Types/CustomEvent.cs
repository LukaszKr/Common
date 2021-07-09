using System.Collections.Generic;

namespace ProceduralLevel.Common.Event
{
	public class CustomEvent: AEvent
	{
		public readonly bool ReverseInvoke = false;

		public CustomEvent(bool reverseInvoke = false)
		{
			ReverseInvoke = reverseInvoke;
		}

		public override void Invoke()
		{
			if(ReverseInvoke)
			{
				int count = m_Listeners.Count-1;
				for(int x = count; x >= 0; x--)
				{
					m_Listeners[x]();
				}
			}
			else
			{
				int count = m_Listeners.Count;
				for(int x = 0; x < count; x++)
				{
					m_Listeners[x]();
				}
			}
		}
	}

	public class CustomEvent<T0>: AEvent<T0>
	{
		public readonly bool ReverseInvoke = false;

		public CustomEvent(bool reverseInvoke = false)
		{
			ReverseInvoke = reverseInvoke;
		}

		public override void Invoke(T0 arg0)
		{
			if(ReverseInvoke)
			{
				int count = m_Listeners.Count-1;
				for(int x = count; x >= 0; x--)
				{
					m_Listeners[x](arg0);
				}
			}
			else
			{
				int count = m_Listeners.Count;
				for(int x = 0; x < count; x++)
				{
					m_Listeners[x](arg0);
				}
			}
		}
	}

	public class CustomEvent<T0, T1>: AEvent<T0, T1>
	{
		public readonly bool ReverseInvoke = false;

		public CustomEvent(bool reverseInvoke = false)
		{
			ReverseInvoke = reverseInvoke;
		}

		public override void Invoke(T0 arg0, T1 arg1)
		{
			if(ReverseInvoke)
			{
				int count = m_Listeners.Count-1;
				for(int x = count; x >= 0; x--)
				{
					m_Listeners[x](arg0, arg1);
				}
			}
			else
			{
				int count = m_Listeners.Count;
				for(int x = 0; x < count; x++)
				{
					m_Listeners[x](arg0, arg1);
				}
			}
		}
	}

	public class CustomEvent<T0, T1, T2>: AEvent<T0, T1, T2>
	{
		public readonly bool ReverseInvoke = false;

		public CustomEvent(bool reverseInvoke = false)
		{
			ReverseInvoke = reverseInvoke;
		}

		public override void Invoke(T0 arg0, T1 arg1, T2 arg2)
		{
			if(ReverseInvoke)
			{
				int count = m_Listeners.Count-1;
				for(int x = count; x >= 0; x--)
				{
					m_Listeners[x](arg0, arg1, arg2);
				}
			}
			else
			{
				int count = m_Listeners.Count;
				for(int x = 0; x < count; x++)
				{
					m_Listeners[x](arg0, arg1, arg2);
				}
			}
		}
	}

	public class CustomEvent<T0, T1, T2, T3>: AEvent<T0, T1, T2, T3>
	{
		public readonly bool ReverseInvoke = false;

		public CustomEvent(bool reverseInvoke = false)
		{
			ReverseInvoke = reverseInvoke;
		}

		public override void Invoke(T0 arg0, T1 arg1, T2 arg2, T3 arg3)
		{
			if(ReverseInvoke)
			{
				int count = m_Listeners.Count-1;
				for(int x = count; x >= 0; x--)
				{
					m_Listeners[x](arg0, arg1, arg2, arg3);
				}
			}
			else
			{
				int count = m_Listeners.Count;
				for(int x = 0; x < count; x++)
				{
					m_Listeners[x](arg0, arg1, arg2, arg3);
				}
			}
		}
	}

}
