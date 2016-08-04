using System.Collections.Generic;

namespace Common.Serialization
{
	public abstract class TextPersistence
    {
		public const char SEPARATOR = ';';
		public const char QUOTATION = '"';

		protected List<string> m_Buffer;

		public TextPersistence()
		{
			m_Buffer = new List<string>();
		}

		public virtual void Clear()
		{
			m_Buffer.Clear();
		}
	}
}
