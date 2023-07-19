namespace ProceduralLevel.Common.Event
{
	public class Observable<TValue>
	{
		private TValue m_Value;

		public TValue Value => m_Value;

		public readonly CustomEvent<TValue> OnChanged = new CustomEvent<TValue>();

		public void Set(TValue value)
		{
			if(Equals(m_Value, value))
			{
				return;
			}

			m_Value = value;
			OnChanged.Invoke(value);
		}

		public override string ToString()
		{
			return $"[Value: '{Value}']";
		}
	}
}
