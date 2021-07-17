using System;
using NUnit.Framework;
using ProceduralLevel.Common.Event;

namespace Tests.Event
{
	[TestFixture]
	public abstract class ABaseEventTests<TEvent, TCallback>
		where TEvent : ABaseEvent<TCallback>, new()
		where TCallback : Delegate
	{
		protected TEvent m_TestEvent;

		[SetUp]
		public virtual void Initialize()
		{
			m_TestEvent = new TEvent();
		}
	}
}
