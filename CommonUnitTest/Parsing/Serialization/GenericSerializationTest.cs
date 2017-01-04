﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralLevel.Common.Serialization;

namespace ProceduralLevel.CommonUnitTest.Parsing
{
	public class SimpleClass
	{
		public int ID = 3;
		public string Name = "test";
		public NestedSimpleClass Nested = new NestedSimpleClass();
		public NestedSimpleClass NullNested = null;
		public int[] SimpleArray = new int[] { 1, 2, 3 };
		public NestedSimpleClass[] NestedSimple = new NestedSimpleClass[] { new NestedSimpleClass(), new NestedSimpleClass() };
	}

	public class NestedSimpleClass
	{
		public int Yay = 1;
		public string Hello = "world";
		public string[] Arr = new string[] { "a", "b" };
	}

	[TestClass]
	public class GenericSerializationTest
	{
		[TestInitialize()]
		public void Initialize()
		{

		}

		[TestMethod]
		public void SerializeTest()
		{
			SimpleClass test = new SimpleClass();
			JsonObjectSerializer serializer = new JsonObjectSerializer();
			Serializer.Serialize(test, serializer);

			Assert.AreEqual(3, serializer.ReadInt("ID"));
			Assert.AreEqual("test", serializer.ReadString("Name"));
			Assert.AreEqual(null, serializer.TryReadObject("NullNested"));

			IObjectSerializer nested = serializer.TryReadObject("Nested");
			AssertNestedSimple(nested);

			IArraySerializer array = serializer.TryReadArray("SimpleArray");
			Assert.AreNotEqual(null, array);
			Assert.AreEqual(3, array.Count);
			Assert.AreEqual(1, array.ReadInt(0));
			Assert.AreEqual(2, array.ReadInt(1));
			Assert.AreEqual(3, array.ReadInt(2));

			array = serializer.TryReadArray("NestedSimple");
			Assert.AreNotEqual(null, array);
			Assert.AreEqual(2, array.Count);
			AssertNestedSimple(array.ReadObject(0));
			AssertNestedSimple(array.ReadObject(1));
		}

		[TestMethod]
		public void DeserializeTest()
		{
			SimpleClass test = new SimpleClass();
			JsonObjectSerializer serializer = new JsonObjectSerializer();
			Serializer.Serialize(test, serializer);
			test = Serializer.Deserialize<SimpleClass>(serializer);

			Assert.AreNotEqual(null, test);

			Assert.AreEqual(3, test.ID);
			Assert.AreEqual("test", test.Name);
			AssertNestedSimple(test.Nested);			
		}

		private void AssertNestedSimple(IObjectSerializer nested)
		{
			Assert.AreNotEqual(null, nested);
			Assert.AreEqual(3, nested.Keys().Length);
			Assert.AreEqual(1, nested.ReadInt("Yay"));
			Assert.AreEqual("world", nested.ReadString("Hello"));
			IArraySerializer arr = nested.ReadArray("Arr");
			Assert.AreEqual("a", arr.ReadString(0));
			Assert.AreEqual("b", arr.ReadString(1));
		}

		private void AssertNestedSimple(NestedSimpleClass nested)
		{
			Assert.AreNotEqual(null, nested);
			Assert.AreEqual(1, nested.Yay);
			Assert.AreEqual("world", nested.Hello);
			Assert.AreNotEqual(null, nested.Arr);
			Assert.AreEqual(2, nested.Arr.Length);
			Assert.AreEqual("a", nested.Arr[0]);
			Assert.AreEqual("b", nested.Arr[1]);
		}
	}
}
