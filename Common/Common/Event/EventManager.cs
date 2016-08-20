using System.Collections.Generic;

namespace Common.Event
{
	public class EventManager
	{
		private Dictionary<int, object> m_Channels;


		public EventManager()
		{
			m_Channels = new Dictionary<int, object>();
		}

		public void Emit<EventType>(EventType message) where EventType : BaseEvent
		{
			GetEventChannel<EventType>(message.EventID).Invoke(message);
		}

		public EventChannel<EventType> GetEventChannel<EventType>(int eventID, bool autoCreate = true) where EventType : BaseEvent
		{
			EventChannel<EventType> channel;
			object baseChannel;
			if(!m_Channels.TryGetValue(eventID, out baseChannel))
			{
				if(autoCreate)
				{
					channel = new EventChannel<EventType>();
					m_Channels[eventID] = channel;
				}
				else
				{
					return null;
				}
			}
			else
			{
				channel = baseChannel as EventChannel<EventType>;
			}
			return channel;
		}
	}
}
