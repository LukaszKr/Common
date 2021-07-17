using System;
using NUnit.Framework;
using ProceduralLevel.Common.SimpleID;

namespace Tests.SimpleID
{
	[TestFixture]
	public class SimpleIDTests
	{
		private IDGroup<ID> m_Group;

		[SetUp]
		public void Initialize()
		{
			m_Group = new IDGroup<ID>();
		}

		[Test]
		public void CreateAndGetID()
		{
			m_Group.RegisterID(new ID(1, "TestID"));
			AssertID(1, "TestID");
		}

		[Test]
		public void PreventDuplicates()
		{
			m_Group.RegisterID(new ID(1, "TestID"));
			Assert.Throws<ArgumentException>(() => m_Group.RegisterID(new ID(1, "DuplicatedID")));
			AssertID(1, "TestID");
		}

		[Test]
		public void ReturnNullIfNotFound()
		{
			m_Group.RegisterID(new ID(1, ""));
			m_Group.RegisterID(new ID(4, ""));
			m_Group.RegisterID(new ID(10, ""));
			m_Group.RegisterID(new ID(2, ""));

			Assert.AreEqual(4, m_Group.Count);
			Assert.IsNull(m_Group.Get(5));
		}

		private void AssertID(uint value, string name = null)
		{
			ID id = m_Group.Get(value);
			Assert.IsNotNull(id);
			Assert.AreEqual(value, id.Value);
			if(name != null)
			{
				Assert.AreEqual(id.Name, name);
			}
		}
	}
}
