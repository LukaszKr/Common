
using System.Collections.Generic;
using System.Diagnostics;

namespace ProceduralLevel.Common.Assertion
{
	public static partial class DebugAssert
	{
		public const string CONDITIONAL = "DEBUG_ASSERT";

		private const float APPROX = 0.00001f;

		#region IsTrue
		[Conditional(CONDITIONAL)]
		public static void IsTrue(bool condition, string message = default)
		{
			Assert.IsTrue(condition, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsTrue<Arg0>(bool condition, string message, Arg0 arg0)
		{
			Assert.IsTrue(condition, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsTrue<Arg0, Arg1>(bool condition, string message, Arg0 arg0, Arg1 arg1)
		{
			Assert.IsTrue(condition, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsTrue<Arg0, Arg1, Arg2>(bool condition, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
		{
			Assert.IsTrue(condition, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsTrue<Arg0, Arg1, Arg2, Arg3>(bool condition, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
		{
			Assert.IsTrue(condition, message);
		}

		#endregion

		#region IsFalse
		[Conditional(CONDITIONAL)]
		public static void IsFalse(bool condition, string message = default)
		{
			Assert.IsFalse(condition, message);
		}
		
		[Conditional(CONDITIONAL)]
		public static void IsFalse<Arg0>(bool condition, string message, Arg0 arg0)
		{
			Assert.IsFalse(condition, message);
		}
		
		[Conditional(CONDITIONAL)]
		public static void IsFalse<Arg0, Arg1>(bool condition, string message, Arg0 arg0, Arg1 arg1)
		{
			Assert.IsFalse(condition, message);
		}
		
		[Conditional(CONDITIONAL)]
		public static void IsFalse<Arg0, Arg1, Arg2>(bool condition, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
		{
			Assert.IsFalse(condition, message);
		}
		
		[Conditional(CONDITIONAL)]
		public static void IsFalse<Arg0, Arg1, Arg2, Arg3>(bool condition, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
		{
			Assert.IsFalse(condition, message);
		}
		
		#endregion

		#region IsNull
		[Conditional(CONDITIONAL)]
		public static void IsNull<T>(T obj, string message = default)
			where T : class
		{
			Assert.IsNull(obj, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsNull<T, Arg0>(T obj, string message, Arg0 arg0)
			where T : class
		{
			Assert.IsNull(obj, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsNull<T, Arg0, Arg1>(T obj, string message, Arg0 arg0, Arg1 arg1)
			where T : class
		{
			Assert.IsNull(obj, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsNull<T, Arg0, Arg1, Arg2>(T obj, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
			where T : class
		{
			Assert.IsNull(obj, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsNull<T, Arg0, Arg1, Arg2, Arg3>(T obj, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
			where T : class
		{
			Assert.IsNull(obj, message);
		}

		#endregion

		#region IsNotNull
		[Conditional(CONDITIONAL)]
		public static void IsNotNull<T>(T obj, string message = default)
			where T : class
		{
			Assert.IsNotNull(obj, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsNotNull<T, Arg0>(T obj, string message, Arg0 arg0)
			where T : class
		{
			Assert.IsNotNull(obj, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsNotNull<T, Arg0, Arg1>(T obj, string message, Arg0 arg0, Arg1 arg1)
			where T : class
		{
			Assert.IsNotNull(obj, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsNotNull<T, Arg0, Arg1, Arg2>(T obj, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
			where T : class
		{
			Assert.IsNotNull(obj, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsNotNull<T, Arg0, Arg1, Arg2, Arg3>(T obj, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
			where T : class
		{
			Assert.IsNotNull(obj, message);
		}

		#endregion

		#region AreEqual
		[Conditional(CONDITIONAL)]
		public static void AreEqual<T>(T expected, T actual, string message = default)
		{
			Assert.AreEqual(expected, actual, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreEqual<T, Arg0>(T expected, T actual, string message, Arg0 arg0)
		{
			Assert.AreEqual(expected, actual, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreEqual<T, Arg0, Arg1>(T expected, T actual, string message, Arg0 arg0, Arg1 arg1)
		{
			Assert.AreEqual(expected, actual, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreEqual<T, Arg0, Arg1, Arg2>(T expected, T actual, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
		{
			Assert.AreEqual(expected, actual, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreEqual<T, Arg0, Arg1, Arg2, Arg3>(T expected, T actual, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
		{
			Assert.AreEqual(expected, actual, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreEqual<T>(T expected, T actual, IEqualityComparer<T> comparer, string message = default)
		{
			Assert.AreEqual(expected, actual, comparer, message);
		}
		[Conditional(CONDITIONAL)]
		public static void AreEqual<T, Arg0>(T expected, T actual, IEqualityComparer<T> comparer, string message, Arg0 arg0)
		{
			Assert.AreEqual(expected, actual, comparer, message);
		}
		[Conditional(CONDITIONAL)]
		public static void AreEqual<T, Arg0, Arg1>(T expected, T actual, IEqualityComparer<T> comparer, string message, Arg0 arg0, Arg1 arg1)
		{
			Assert.AreEqual(expected, actual, comparer, message);
		}
		[Conditional(CONDITIONAL)]
		public static void AreEqual<T, Arg0, Arg1, Arg2>(T expected, T actual, IEqualityComparer<T> comparer, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
		{
			Assert.AreEqual(expected, actual, comparer, message);
		}
		[Conditional(CONDITIONAL)]
		public static void AreEqual<T, Arg0, Arg1, Arg2, Arg3>(T expected, T actual, IEqualityComparer<T> comparer, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
		{
			Assert.AreEqual(expected, actual, comparer, message);
		}
		#endregion

		#region AreNotEqual
		[Conditional(CONDITIONAL)]
		public static void AreNotEqual<T>(T expected, T actual, string message = default)
		{
			Assert.AreNotEqual(expected, actual, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotEqual<T, Arg0>(T expected, T actual, string message, Arg0 arg0)
		{
			Assert.AreNotEqual(expected, actual, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotEqual<T, Arg0, Arg1>(T expected, T actual, string message, Arg0 arg0, Arg1 arg1)
		{
			Assert.AreNotEqual(expected, actual, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotEqual<T, Arg0, Arg1, Arg2>(T expected, T actual, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
		{
			Assert.AreNotEqual(expected, actual, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotEqual<T, Arg0, Arg1, Arg2, Arg3>(T expected, T actual, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
		{
			Assert.AreNotEqual(expected, actual, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotEqual<T>(T expected, T actual, IEqualityComparer<T> comparer, string message = default)
		{
			Assert.AreNotEqual(expected, actual, comparer, message);
		}
		[Conditional(CONDITIONAL)]
		public static void AreNotEqual<T, Arg0>(T expected, T actual, IEqualityComparer<T> comparer, string message, Arg0 arg0)
		{
			Assert.AreNotEqual(expected, actual, comparer, message);
		}
		[Conditional(CONDITIONAL)]
		public static void AreNotEqual<T, Arg0, Arg1>(T expected, T actual, IEqualityComparer<T> comparer, string message, Arg0 arg0, Arg1 arg1)
		{
			Assert.AreNotEqual(expected, actual, comparer, message);
		}
		[Conditional(CONDITIONAL)]
		public static void AreNotEqual<T, Arg0, Arg1, Arg2>(T expected, T actual, IEqualityComparer<T> comparer, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
		{
			Assert.AreNotEqual(expected, actual, comparer, message);
		}
		[Conditional(CONDITIONAL)]
		public static void AreNotEqual<T, Arg0, Arg1, Arg2, Arg3>(T expected, T actual, IEqualityComparer<T> comparer, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
		{
			Assert.AreNotEqual(expected, actual, comparer, message);
		}
		#endregion

		#region AreApproximatelyEqual
		[Conditional(CONDITIONAL)]
		public static void AreApproximatelyEqual(float expected, float actual, string message = default)
		{
			Assert.AreApproximatelyEqual(expected, actual, APPROX, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreApproximatelyEqual<Arg0>(float expected, float actual, string message, Arg0 arg0)
		{
			Assert.AreApproximatelyEqual(expected, actual, APPROX, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreApproximatelyEqual<Arg0, Arg1>(float expected, float actual, string message, Arg0 arg0, Arg1 arg1)
		{
			Assert.AreApproximatelyEqual(expected, actual, APPROX, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreApproximatelyEqual<Arg0, Arg1, Arg2>(float expected, float actual, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
		{
			Assert.AreApproximatelyEqual(expected, actual, APPROX, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreApproximatelyEqual<Arg0, Arg1, Arg2, Arg3>(float expected, float actual, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
		{
			Assert.AreApproximatelyEqual(expected, actual, APPROX, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreApproximatelyEqual(float expected, float actual, float tolerance, string message = default)
		{
			Assert.AreApproximatelyEqual(expected, actual, tolerance, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreApproximatelyEqual<Arg0>(float expected, float actual, float tolerance, string message, Arg0 arg0)
		{
			Assert.AreApproximatelyEqual(expected, actual, tolerance, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreApproximatelyEqual<Arg0, Arg1>(float expected, float actual, float tolerance, string message, Arg0 arg0, Arg1 arg1)
		{
			Assert.AreApproximatelyEqual(expected, actual, tolerance, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreApproximatelyEqual<Arg0, Arg1, Arg2>(float expected, float actual, float tolerance, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
		{
			Assert.AreApproximatelyEqual(expected, actual, tolerance, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreApproximatelyEqual<Arg0, Arg1, Arg2, Arg3>(float expected, float actual, float tolerance, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
		{
			Assert.AreApproximatelyEqual(expected, actual, tolerance, message);
		}

		#endregion

		#region AreNotApproximatelyEqual
		[Conditional(CONDITIONAL)]
		public static void AreNotApproximatelyEqual(float expected, float actual, string message = default)
		{
			Assert.AreNotApproximatelyEqual(expected, actual, APPROX, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotApproximatelyEqual<Arg0>(float expected, float actual, string message, Arg0 arg0)
		{
			Assert.AreNotApproximatelyEqual(expected, actual, APPROX, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotApproximatelyEqual<Arg0, Arg1>(float expected, float actual, string message, Arg0 arg0, Arg1 arg1)
		{
			Assert.AreNotApproximatelyEqual(expected, actual, APPROX, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotApproximatelyEqual<Arg0, Arg1, Arg2>(float expected, float actual, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
		{
			Assert.AreNotApproximatelyEqual(expected, actual, APPROX, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotApproximatelyEqual<Arg0, Arg1, Arg2, Arg3>(float expected, float actual, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
		{
			Assert.AreNotApproximatelyEqual(expected, actual, APPROX, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotApproximatelyEqual(float expected, float actual, float tolerance, string message = default)
		{
			Assert.AreNotApproximatelyEqual(expected, actual, tolerance, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotApproximatelyEqual<Arg0>(float expected, float actual, float tolerance, string message, Arg0 arg0)
		{
			Assert.AreNotApproximatelyEqual(expected, actual, tolerance, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotApproximatelyEqual<Arg0, Arg1>(float expected, float actual, float tolerance, string message, Arg0 arg0, Arg1 arg1)
		{
			Assert.AreNotApproximatelyEqual(expected, actual, tolerance, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotApproximatelyEqual<Arg0, Arg1, Arg2>(float expected, float actual, float tolerance, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
		{
			Assert.AreNotApproximatelyEqual(expected, actual, tolerance, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotApproximatelyEqual<Arg0, Arg1, Arg2, Arg3>(float expected, float actual, float tolerance, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
		{
			Assert.AreNotApproximatelyEqual(expected, actual, tolerance, message);
		}

		#endregion
	}
}
