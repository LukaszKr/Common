using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Event
{
    public class EventChannelGroup
    {
		private Dictionary<Type, object> m_Channels;

		public EventChannelGroup()
		{
			m_Channels = new Dictionary<Type, object>();
		}

		public EventChannel<EventType> GetEventChannel<EventType>(bool autoCreate = true) where EventType : BaseEvent
		{
			EventChannel<EventType> channel;
			object baseChannel;
			Type type = typeof(EventType);
			if(!m_Channels.TryGetValue(type, out baseChannel))
			{
				if(autoCreate)
				{
					channel = new EventChannel<EventType>();
					m_Channels[type] = channel;
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
