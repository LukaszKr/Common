using NUnit.Framework;
using ProceduralLevel.Common.Event;

namespace Tests.Event
{
	[TestFixture]
	public abstract class AEventTests<TEvent>
		: ABaseEventTests<TEvent, AEvent<int>.Callback>
		where TEvent : AEvent<int>, new()
	{
		protected const int TEST_VALUE = 1;

		protected bool m_CallbackCalled = false;
		protected int m_RecvValue;

		public override void Initialize()
		{
			base.Initialize();

			m_CallbackCalled = false;
			m_RecvValue = 0;
		}

		[Test]
		public void AddInvokeRemove()
		{
			AssertCleanState();
			
			m_TestEvent.AddListener(CalledIndicatorCallback);
			Assert.AreEqual(1, m_TestEvent.ListenerCount);

			m_TestEvent.Invoke(TEST_VALUE);
			AssertCallback();

			m_TestEvent.RemoveListener(CalledIndicatorCallback);
			Assert.AreEqual(0, m_TestEvent.ListenerCount);
		}

		#region Helpers
		protected void AssertCallback()
		{
			Assert.AreEqual(TEST_VALUE, m_RecvValue);
			Assert.IsTrue(m_CallbackCalled);
		}

		protected void AssertCleanState()
		{
			Assert.IsFalse(m_CallbackCalled);
			Assert.AreEqual(0, m_RecvValue);
			Assert.AreEqual(0, m_TestEvent.ListenerCount);
		}

		protected void SelfRemoveCallback(int value)
		{
			m_TestEvent.RemoveListener(SelfRemoveCallback);
		}

		protected void DummyCallback(int value)
		{

		}

		protected void CalledIndicatorCallback(int value)
		{
			m_RecvValue = value;
			m_CallbackCalled = true;
		}
		#endregion
	}
}
