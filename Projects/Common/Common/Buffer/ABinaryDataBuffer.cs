using System;

namespace ProceduralLevel.Common.Buffer
{
	public abstract class ABinaryBuffer

	{
		protected const int GUID_LENGTH = 16;

		protected readonly byte[] m_Buffer;
		protected int m_Position;

		public byte[] Buffer { get { return m_Buffer; } }
		public int Position { get { return m_Position; } }

		protected ABinaryBuffer(int maxCapacity)
		{
			m_Buffer = new byte[maxCapacity];
		}

		protected ABinaryBuffer(byte[] buffer)
		{
			m_Buffer = buffer;
		}

		public void Seek(int position, ESeekOrigin origin = ESeekOrigin.Begin)
		{
			switch(origin)
			{
				case ESeekOrigin.Begin:
					m_Position = position;
					break;
				case ESeekOrigin.Current:
					m_Position += position;
					break;
				case ESeekOrigin.End:
					m_Position = m_Buffer.Length-position;
					break;
				default:
					throw new NotImplementedException();
			}
		}

		public override string ToString()
		{
			return $"[Position: {m_Position}, Capacity: {m_Buffer.Length}]";
		}
	}
}
