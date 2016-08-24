using System.Collections.Generic;

namespace ProceduralLevel.Common.Serialization
{
	public abstract class TextPersistence
    {
		protected List<string> m_Buffer;

		public char Separator { get; private set; }
		public char StringMarker { get; private set; }

		public int Count { get { return m_Buffer.Count; } }

		public TextPersistence(char separator, char stringMarker)
		{
			Separator = separator;
			StringMarker = stringMarker;
			m_Buffer = new List<string>();
		}

		public virtual void Clear()
		{
			m_Buffer.Clear();
		}
	}
}
