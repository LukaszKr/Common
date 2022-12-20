using System;
using NUnit.Framework;
using ProceduralLevel.Common.Context;
using ProceduralLevel.Common.Event;

namespace Tests.Context
{
	[TestFixture]
	public class ContextTests
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

			protected override void OnReplace(EventBinder binder, TestClassData oldContext, TestClassData newContext)
			{
				ReplaceCallCount++;
			}
		}

		[Test]
		public void SetAndRemoveContextData()
		{
			TestClass instance = new TestClass();
			TestClassData data = new TestClassData();
			instance.SetContext(data);
			instance.SetContext(null);
			Assert.AreEqual(1, instance.AttachCallCount);
			Assert.AreEqual(1, instance.DetachCallCount);
		}

		[Test]
		public void ReplaceMethodWasCalled()
		{
			TestClass instance = new TestClass();
			TestClassData data1 = new TestClassData();
			TestClassData data2 = new TestClassData();
			instance.SetContext(data1);
			instance.SetContext(data2);
			instance.SetContext(null);

			Assert.AreEqual(1, instance.AttachCallCount);
			Assert.AreEqual(1, instance.ReplaceCallCount);
			Assert.AreEqual(1, instance.DetachCallCount);
		}

		[Test]
		public void TrySetTheSameContextDataTwice()
		{
			TestClass instance = new TestClass();
			TestClassData data = new TestClassData();
			instance.SetContext(data);
			Assert.Throws<InvalidOperationException>(() => instance.SetContext(data));
		}

		[Test]
		public void TrySetNullContextToClassThatAlreadyHasNoContext()
		{
			TestClass instance = new TestClass();
			Assert.Throws<InvalidOperationException>(() => instance.SetContext(null));
		}
	}
}
