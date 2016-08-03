using System;

namespace Common.Logger
{
	public class Logger
    {
		public ILogWriter Writer { get; private set; }

		public Logger(ILogWriter writer = null)
		{
			if(writer != null)
			{
				Writer = writer;
			}
			else
			{
				Writer = new DummyLogWriter();
			}
		}

		public void WriteLog(object source, string message)
		{
			WriteLine(source, message);
		}

		public void WriteLog(object source, string format, params string[] args)
		{
			WriteLine(source, string.Format(format, args));
		}

		public void WriteLog(object source, Exception exception)
		{
			string line = string.Format("{0}\n{1}", exception.Message, exception.StackTrace);
			WriteLine(source, line);
		}

		private void WriteLine(object source, string message)
		{
			Writer.WriteLine(string.Format("[{0}]{1}", source.GetType().Name, message));
		}
    }
}
