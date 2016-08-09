using System;

namespace Common.Serialization
{
	public class BinarySerializer: BinaryPersistence, ISerializer
	{
		public BinarySerializer()
		{
			throw new NotImplementedException();
		}

		public override void Clear()
		{
			base.Clear();
			throw new NotImplementedException();
		}

		public void Save(IDataWriter writer)
		{
			throw new NotImplementedException();
		}

		#region Write
		public void Write(long data)
		{
			throw new NotImplementedException();
		}

		public void Write(double data)
		{
			throw new NotImplementedException();
		}

		public void Write(string data)
		{
			throw new NotImplementedException();
		}

		public void Write(float data)
		{
			throw new NotImplementedException();
		}

		public void Write(int data)
		{
			throw new NotImplementedException();
		}

		public void Write(short data)
		{
			throw new NotImplementedException();
		}

		public void Write(byte data)
		{
			throw new NotImplementedException();
		}

		public void Write(bool data)
		{
			throw new NotImplementedException();
		}

		public void Write(ISerializable serializable)
		{
			serializable.Serialize(this);
		}
		#endregion
	}
}
