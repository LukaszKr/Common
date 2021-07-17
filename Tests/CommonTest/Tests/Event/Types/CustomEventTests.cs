using NUnit.Framework;
using ProceduralLevel.Common.Event;

namespace Tests.Event.Types
{
	[TestFixture]
	public class CustomEventTests: AEventTests<CustomEvent<int>>
	{
		[Test]
		public void RemoveFirstDuringInvoke()
		{
			AssertCleanState();

			m_TestEvent.AddListener(SelfRemoveCallback);
			m_TestEvent.AddListener(CalledIndicatorCallback);
			Assert.AreEqual(2, m_TestEvent.ListenerCount);

			m_TestEvent.Invoke(TEST_VALUE);
			AssertCallback();
			Assert.AreEqual(1, m_TestEvent.ListenerCount);
		}

		[Test]
		public void RemoveLastDuringInvoke()
		{
			AssertCleanState();

			m_TestEvent.AddListener(CalledIndicatorCallback);
			m_TestEvent.AddListener(SelfRemoveCallback);
			Assert.AreEqual(2, m_TestEvent.ListenerCount);

			m_TestEvent.Invoke(1);
			AssertCallback();
			Assert.AreEqual(1, m_TestEvent.ListenerCount);
		}

		[Test]
		public void RemoveMiddleDuringInvoke()
		{
			AssertCleanState();

			m_TestEvent.AddListener(DummyCallback);
			m_TestEvent.AddListener(SelfRemoveCallback);
			m_TestEvent.AddListener(CalledIndicatorCallback);
			Assert.AreEqual(3, m_TestEvent.ListenerCount);

			m_TestEvent.Invoke(TEST_VALUE);
			AssertCallback();
			Assert.AreEqual(2, m_TestEvent.ListenerCount);
		}

		[Test]
		public void RemoveMultipleDuringInvoke()
		{
			AssertCleanState();

			m_TestEvent.AddListener(DummyCallback);
			m_TestEvent.AddListener(SelfRemoveCallback);
			m_TestEvent.AddListener(SelfRemoveCallback);
			m_TestEvent.AddListener(DummyCallback);
			m_TestEvent.AddListener(CalledIndicatorCallback);
			Assert.AreEqual(5, m_TestEvent.ListenerCount);

			m_TestEvent.Invoke(TEST_VALUE);
			AssertCallback();
			Assert.AreEqual(3, m_TestEvent.ListenerCount);
		}
	}
}
