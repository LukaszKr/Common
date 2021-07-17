using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ProceduralLevel.Common.Event;

namespace Tests.Event
{
	[TestFixture]
	public class CustomEventTest
	{
		private CustomEvent<int> m_TestEvent;

		[SetUp]
		public void Initialize()
		{
			m_TestEvent = new CustomEvent<int>();
		}

		[Test]
		public void AddInvokeRemove()
		{
			const int sentValue = 1;

			bool callbackCalled = false;
			int recvdValue = 0;
			void Callback(int value)
			{
				callbackCalled = true;
				recvdValue = value;
			}

			m_TestEvent.AddListener(Callback);
			Assert.AreEqual(1, m_TestEvent.ListenerCount);
			m_TestEvent.Invoke(sentValue);
			m_TestEvent.RemoveListener(Callback);
			Assert.AreEqual(0, m_TestEvent.ListenerCount);

			Assert.AreEqual(sentValue, recvdValue);
			Assert.IsTrue(callbackCalled);
		}
	}
}
