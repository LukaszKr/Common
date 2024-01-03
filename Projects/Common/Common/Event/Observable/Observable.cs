namespace ProceduralLevel.Common.Event
{
	public class Observable<TValue>
	{
		private TValue m_Value;

		public TValue Value
		{
			get => m_Value;
			set => Set(value);
		}

		public readonly CustomEvent<TValue> OnChanged = new CustomEvent<TValue>();

		public static implicit operator TValue(Observable<TValue> o) => o.Value;

		public Observable()
		{
		}

		public Observable(TValue initialValue)
		{
			m_Value = initialValue;
		}

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
