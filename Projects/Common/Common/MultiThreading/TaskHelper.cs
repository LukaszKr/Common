using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProceduralLevel.Common.MultiThreading
{
	public class TaskHelper
	{
		private readonly Dictionary<int, Task[]> m_TasksBuffers = new Dictionary<int, Task[]>();
		public int DefaultTaskCount;

		public TaskHelper()
		{
			DefaultTaskCount = Math.Max(1, Environment.ProcessorCount);
		}

		private Task[] GetTaskBuffer(int tasksCount)
		{
			Task[] buffer;
			if(!m_TasksBuffers.TryGetValue(tasksCount, out buffer))
			{
				buffer = new Task[tasksCount];
				m_TasksBuffers[tasksCount] = buffer;
			}
			return buffer;
		}

		public void RunAndWaitAll(Action action)
		{
			if(DefaultTaskCount == 1)
			{
				action();
				return;
			}

			Task[] buffer = GetTaskBuffer(DefaultTaskCount);
			for(int x = 0; x < DefaultTaskCount; ++x)
			{
				buffer[x] = Task.Run(action);
			}
			RunAndWaitAll(buffer);
		}

		public void RunAndWaitAll<TTaskData>(Action<TTaskData> action, TTaskData[] tasksData)
		{
			int taskCount = tasksData.Length;
			Task[] buffer = GetTaskBuffer(taskCount);

			for(int x = 0; x < taskCount; ++x)
			{
				TTaskData taskData = tasksData[x];
				buffer[x] = Task.Run(() => action(taskData));
			}
			RunAndWaitAll(buffer);
		}

		public void RunAndWaitAll(Task[] taskBuffer)
		{
			int taskCount = taskBuffer.Length;
			Task.WaitAll(taskBuffer);
			for(int x = 0; x < taskCount; ++x)
			{
				taskBuffer[x].Dispose();
				taskBuffer[x] = null;
			}
		}
	}
}
