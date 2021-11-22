using System;

namespace ProceduralLevel.Common.Assertion
{
	public class AssertException : Exception
	{
		public AssertException(string message)
			: base(message)
		{
		}
	}
}
