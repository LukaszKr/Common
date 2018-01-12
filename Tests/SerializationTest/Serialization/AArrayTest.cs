using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralLevel.Common.Serialization;

namespace Test.Serialization
{
    [TestClass]
	public abstract class AArrayTest<T> where T : AArray
	{
		protected abstract AArray CreateArray();

		private AArray m_Array;

		[TestInitialize]
		public void Initialize()
		{
			m_Array = CreateArray();
		}

		[TestMethod]
		public void BasicWriteAndRead()
		{
			int iVal = 123;
			bool bVal = true;
			string sVal = "hello";
			float fVal = 123.123f;

			m_Array.Write(iVal)
					.Write(bVal)
					.Write(sVal)
					.Write(fVal);

			Assert.AreEqual(iVal, m_Array.ReadInt());
			Assert.AreEqual(bVal, m_Array.ReadBool());
			Assert.AreEqual(sVal, m_Array.ReadString());
			Assert.AreEqual(fVal, m_Array.ReadFloat());

			Assert.AreEqual(iVal, m_Array.ReadInt(0));
			Assert.AreEqual(bVal, m_Array.ReadBool(1));
			Assert.AreEqual(sVal, m_Array.ReadString(2));
			Assert.AreEqual(fVal, m_Array.ReadFloat(3));
		}

		[TestMethod]
		public void ToStringTest()
		{
			Assert.AreEqual("[]", m_Array.ToString(false));

			m_Array.Write(123);
			Assert.AreEqual("[123]", m_Array.ToString(false));
		}
	}
}
