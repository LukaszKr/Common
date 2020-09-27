using System;
using System.Collections.Generic;

namespace ProceduralLevel.Common.Log
{
	public class Logger<TChannel>
	{
		private readonly List<ALogHandler<TChannel>> m_Handlers = new List<ALogHandler<TChannel>>();

		public void AddHandler(ALogHandler<TChannel> handler)
		{
			m_Handlers.Add(handler);
		}

		public void Log(ELogLevel level, TChannel channel, object source, string msg)
		{
			int count = m_Handlers.Count;
			for(int x = 0; x < count; ++x)
			{
				ALogHandler<TChannel> handler = m_Handlers[x];
				handler.Log(level, channel, source, msg);
			}
		}

		public void Log(TChannel channel, object source, Exception e)
		{
			Log(ELogLevel.Exception, channel, source, e.ToString());
		}

		public void LogDebug(TChannel channel, object source, string message)
		{
			Log(ELogLevel.Debug, channel, source, message);
		}

		public void LogInfo(TChannel channel, object source, string message)
		{
			Log(ELogLevel.Info, channel, source, message);
		}

		public void LogWarning(TChannel channel, object source, string message)
		{
			Log(ELogLevel.Warning, channel, source, message);
		}

		public void LogError(TChannel channel, object source, string message)
		{
			Log(ELogLevel.Error, channel, source, message);
		}
	}
}
