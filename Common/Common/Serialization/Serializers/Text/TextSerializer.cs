using System;
using System.Text;

namespace Common.Serialization
{
	public class TextSerializer: TextPersistence, ISerializer
	{
		private int m_BufferedData = 0;

		public TextSerializer(char separator = ';', char stringMarker = '"') : base(separator, stringMarker)
		{
		}

		public override void Clear()
		{
			base.Clear();
			m_BufferedData = 0;
		}

		public void Save(IDataWriter writer)
		{
			writer.Write(ToString());
		}

		public override string ToString()
		{
			StringBuilder builder = new StringBuilder(m_BufferedData+m_Buffer.Count-1);
			for(int x = 0; x < m_Buffer.Count; x++)
			{
				builder.Append(m_Buffer[x]);
				if(x < m_Buffer.Count-1)
				{
					builder.Append(Separator);
				}
			}
			return builder.ToString();
		}

		#region Write
		private void AddToBuffer(string str)
		{
			m_BufferedData += str.Length;
			m_Buffer.Add(str);
		}

		public void Write(IPairSerializable serializable)
		{
			throw new NotSupportedException();
		}

		public void Write(ISerializable serializable)
		{
			serializable.Serialize(this);
		}

		public void Write(string data)
		{
			AddToBuffer(StringMarker+data.ToString()+StringMarker);
		}

		public void Write(object data)
		{
			AddToBuffer(data.ToString());
		}
		#endregion
	}
}
