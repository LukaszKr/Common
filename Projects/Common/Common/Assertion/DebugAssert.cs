using System.Collections.Generic;
using System.Diagnostics;

namespace ProceduralLevel.Common.Assertion
{
	public static partial class DebugAssert
	{
		public const string CONDITIONAL = "DEBUG_ASSERT";

		private const float APPROX = 0.00001f;

		[Conditional(CONDITIONAL)]
		public static void IsTrue(bool condition, string message = "")
		{
			Assert.IsTrue(condition, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsFalse(bool condition, string message = "")
		{
			Assert.IsFalse(condition, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsNull<T>(T obj, string message = "")
			where T : class
		{
			Assert.IsNull(obj, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsNotNull<T>(T obj, string message = "")
			where T : class
		{
			Assert.IsNotNull(obj, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreEqual<T>(T expected, T actual, string message = "")
		{
			Assert.AreEqual(expected, actual, null, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotEqual<T>(T expected, T actual, string message = "")
		{
			Assert.AreNotEqual(expected, actual, null, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreEqual<T>(T expected, T actual, IEqualityComparer<T> comparer, string message = "")
		{
			Assert.AreEqual(expected, actual, comparer, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotEqual<T>(T expected, T actual, IEqualityComparer<T> comparer, string message = "")
		{
			Assert.AreNotEqual(expected, actual, comparer, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreApproximatelyEqual(float expected, float actual, string message = "")
		{
			Assert.AreApproximatelyEqual(expected, actual, APPROX, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotApproximatelyEqual(float expected, float actual, string message = "")
		{
			Assert.AreNotApproximatelyEqual(expected, actual, APPROX, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreApproximatelyEqual(float expected, float actual, float tolerance, string message = "")
		{
			Assert.AreApproximatelyEqual(expected, actual, tolerance, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotApproximatelyEqual(float expected, float actual, float tolerance, string message = "")
		{
			Assert.AreNotApproximatelyEqual(expected, actual, tolerance, message);
		}
	}
}
