using System.Collections.Generic;

namespace Common.Serialization
{
	public abstract class JsonPersistence
    {
		public const char BRACKETS_OPEN = '{';
		public const char BRACKETS_CLOSE = '}';
		public const char KEY_VALUE_SEPARATOR = ':';
		public const char PAIR_SEPARATOR = ',';
		public const char QUOTATION = '"';
		public const char NEW_LINE = '\n';

		protected Dictionary<string, string> m_Parameters;

		public JsonPersistence()
		{
			m_Parameters = new Dictionary<string, string>();
		}

		public virtual void Clear()
		{
			m_Parameters.Clear();
		}
    }
}
