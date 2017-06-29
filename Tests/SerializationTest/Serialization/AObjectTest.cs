using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralLevel.Serialization;

namespace Test.Serialization
{
	[TestClass]
	public abstract class AObjectTest<T> where T: AObject
	{
		protected abstract AObject CreateObject();

		private AObject m_Object;

		[TestInitialize]
		public void Initialize()
		{
			m_Object = CreateObject();
		}

		[TestMethod]
		public void BasicWriteAndRead()
		{
			int iVal = 123;
			bool bVal = true;
			string sVal = "hello";
			float fVal = 123.123f;

			m_Object.Write("i", iVal)
					.Write("b", bVal)
					.Write("s", sVal)
					.Write("f", fVal);

			Assert.AreEqual(iVal, m_Object.ReadInt("i"));
			Assert.AreEqual(bVal, m_Object.ReadBool("b"));
			Assert.AreEqual(sVal, m_Object.ReadString("s"));
			Assert.AreEqual(fVal, m_Object.ReadFloat("f"));
		}

		[TestMethod]
		public void ToStringTest()
		{
			Assert.AreEqual("{}", m_Object.ToString(false));
			
			m_Object.Write("i", 123);
			Assert.AreEqual("{\"i\":123}", m_Object.ToString(false));

		}
	}
}
