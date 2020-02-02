using ProceduralLevel.Common.Easing;
using ProceduralLevel.Common.Event;

namespace ProceduralLevel.Common.Tween
{
	public abstract class AValueTween<TValue>: AEasingTween
	{
		private readonly TValue m_Source;
		private readonly TValue m_Target;

		public TValue Value { get; private set; }

		public readonly CustomEvent<TValue> OnValueChanged = new CustomEvent<TValue>();

		public AValueTween(EasingFunc easing, TValue source, TValue target)
			: base(easing)
		{
			m_Source = source;
			m_Target = target;
		}

		protected override void Start()
		{
		}

		protected override void Finish()
		{
		}

		protected override void OnProgressChanged(float progress)
		{
			float reverseBlend = 1f-progress;
			Value = Blend(m_Source, m_Target, progress, reverseBlend);
			OnValueChanged.Invoke(Value);
		}

		protected abstract TValue Blend(TValue source, TValue target, float blend, float reverseBlend);
	}
}
