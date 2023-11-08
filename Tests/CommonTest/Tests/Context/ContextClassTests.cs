using System;
using NUnit.Framework;
using ProceduralLevel.Common.Context;
using ProceduralLevel.Common.Event;

namespace Tests.Context
{
	[TestFixture]
	public class ContextClassTests
	{
		private class TestClassData
		{

		}

		private class TestClass : AContextClass<TestClassData>
		{
			public int AttachCallCount;
			public int DetachCallCount;
			public int ReplaceCallCount;

			protected override void OnAttach(EventBinder binder)
			{
				AttachCallCount++;
			}

			protected override void OnDetach()
			{
				DetachCallCount++;
			}

			protected override void OnReplace(EventBinder binder, TestClassData oldContext)
			{
				ReplaceCallCount++;
			}
		}

		[Test]
		public void SetAndClearContext()
		{
			TestClass instance = new TestClass();
			TestClassData data = new TestClassData();
			instance.SetContext(data);
			instance.ClearContext();
			Assert.AreEqual(1, instance.AttachCallCount);
			Assert.AreEqual(1, instance.DetachCallCount);
		}

		[Test]
		public void ReplaceContextWithDifferentContext()
		{
			TestClass instance = new TestClass();
			TestClassData data1 = new TestClassData();
			TestClassData data2 = new TestClassData();
			instance.SetContext(data1);
			instance.SetContext(data2);
			instance.ClearContext();

			Assert.AreEqual(1, instance.AttachCallCount);
			Assert.AreEqual(1, instance.ReplaceCallCount);
			Assert.AreEqual(1, instance.DetachCallCount);
		}

		[Test]
		public void ReplaceContextWithTheSameContext()
		{
			TestClass instance = new TestClass();
			TestClassData data1 = new TestClassData();
			instance.SetContext(data1);
			instance.SetContext(data1);
			instance.ClearContext();

			Assert.AreEqual(1, instance.AttachCallCount);
			Assert.AreEqual(1, instance.ReplaceCallCount);
			Assert.AreEqual(1, instance.DetachCallCount);
		}
	}
}
