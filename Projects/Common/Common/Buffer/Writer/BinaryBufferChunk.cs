namespace ProceduralLevel.Common.Buffer
{
	public class BinaryBufferChunk
	{
		private readonly BinaryBufferWriter m_Writer;
		private readonly int m_StartPosition;
		private readonly int m_LengthPosition;

		public BinaryBufferChunk(BinaryBufferWriter writer)
		{
			m_Writer = writer;
			m_StartPosition = m_Writer.Position;
			m_Writer.Write(0);
			m_LengthPosition = m_Writer.Position;
		}

		public int WriteLength()
		{
			int currentPosition = m_Writer.Position;
			int length = currentPosition-m_LengthPosition;

			m_Writer.Seek(m_StartPosition, ESeekOrigin.Begin);
			m_Writer.Write(length);
			m_Writer.Seek(currentPosition, ESeekOrigin.Begin);
			return length;
		}
	}
}
