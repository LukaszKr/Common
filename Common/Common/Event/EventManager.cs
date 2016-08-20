using System.Collections.Generic;

namespace Common.Event
{
	public class EventManager
	{
		private Dictionary<int, EventChannelGroup> m_Channels;

		public EventManager()
		{
			m_Channels = new Dictionary<int, EventChannelGroup>();
		}

		public void Emit<EventType>(EventType message) where EventType : BaseEvent
		{
			GetEventChannel<EventType>(message.EventID).Invoke(message);
		}

		public EventChannel<EventType> GetEventChannel<EventType>(int eventID, bool autoCreate = true) where EventType : BaseEvent
		{
			EventChannelGroup channelGroup;
			if(!m_Channels.TryGetValue(eventID, out channelGroup))
			{
				if(autoCreate)
				{
					channelGroup = new EventChannelGroup();
					m_Channels[eventID] = channelGroup;
				}
				else
				{
					return null;
				}
			}
			return channelGroup.GetEventChannel<EventType>(autoCreate);
		}
	}
}
