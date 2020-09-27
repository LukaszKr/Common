using System;

namespace ProceduralLevel.Common.Log
{
	public abstract class ALogHandler<TLogChannel>
	{
		public abstract void Log(ELogLevel level, TLogChannel channel, object source, string msg);
	}
}
