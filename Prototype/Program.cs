using ProceduralLevel.Common.Serialization;
using System;

namespace Prototype
{
	public class SimpleTest
	{
		public int number = 1;
		public string str = "Hello World!";
		public NestedTest nested = new NestedTest();
		public int[] someArray = new [] { 1, 2, 3 };

		public bool Compare(SimpleTest other)
		{
			if(number != other.number
					|| str != other.str
					|| someArray.Length != other.someArray.Length)
			{
				return false;
			}

			int length = someArray.Length;
			for(int x = 0; x < length; x++)
			{
				if(someArray[x] != other.someArray[x])
				{
					return false;
				}
			}

			return true;
		}
	}

	public class NestedTest
	{
		public int oho = 5;
		public string ey = "hey!";
	}

	public class Program
	{
		static void Main(string[] args)
		{
			JsonObjectSerializer serializer = new JsonObjectSerializer();
			SimpleTest test = new SimpleTest();
			Serializer.Serialize(test, serializer);
			SimpleTest test2 = Serializer.Deserialize<SimpleTest>(serializer);
			if(test.Compare(test))
			{
				Console.WriteLine("SUCCESS!");
			}
			else
			{
				Console.WriteLine("FAILURE!");
			}
		}
	}
}
