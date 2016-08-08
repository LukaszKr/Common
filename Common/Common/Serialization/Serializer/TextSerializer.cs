using System.Text;

namespace Common.Serialization
{
	public class TextSerializer: TextPersistence, ISerializer
	{
		private int m_BufferedData = 0;

		public int Count { get { return m_Buffer.Count; } }

		public override void Clear()
		{
			base.Clear();
			m_BufferedData = 0;
		}

		public void Save(IDataWriter writer)
		{
			StringBuilder builder = new StringBuilder(m_BufferedData+m_Buffer.Count-1);
			for(int x = 0; x < m_Buffer.Count; x++)
			{
				builder.Append(m_Buffer[x]);
				builder.Append(SEPARATOR);
			}
			writer.Write(builder.ToString());
		}

		#region Write
		private void AddToBuffer(string str)
		{
			m_BufferedData += str.Length;
			m_Buffer.Add(str);
		}

		public void Write(long data)
		{
			AddToBuffer(data.ToString());
		}

		public void Write(double data)
		{
			AddToBuffer(data.ToString());
		}

		public void Write(string data)
		{
			AddToBuffer(QUOTATION+data.ToString()+QUOTATION);
		}

		public void Write(float data)
		{
			AddToBuffer(data.ToString());
		}

		public void Write(int data)
		{
			AddToBuffer(data.ToString());
		}

		public void Write(short data)
		{
			AddToBuffer(data.ToString());
		}

		public void Write(byte data)
		{
			AddToBuffer(data.ToString());
		}

		public void Write(bool data)
		{
			AddToBuffer(data.ToString());
		}

		public void Write(ISerializable serializable)
		{
			serializable.Serialize(this);
		}
		#endregion
	}
}
