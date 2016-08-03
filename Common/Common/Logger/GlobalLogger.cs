using System;

namespace Common.Logger
{
	public static class GlobalLogger
    {
		public static Logger Logger;

		public static void WriteLog(object source, string message)
		{
			Logger.WriteLog(source, message);
		}

		public static void WriteLog(object source, string format, params string[] args)
		{
			Logger.WriteLog(source, format, args);
		}

		public static void WriteLog(object source, Exception exception)
		{
			Logger.WriteLog(source, exception);
		}
    }
}
