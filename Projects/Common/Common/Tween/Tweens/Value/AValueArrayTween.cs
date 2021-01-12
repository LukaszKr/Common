using ProceduralLevel.Common.Easing;
using ProceduralLevel.Common.Event;

namespace ProceduralLevel.Common.Tween
{
	public abstract class AValueArrayTween<TValue>: AEasingTween
	{
		private readonly TValue[] m_Buffer;
		private readonly TValue[] m_Source;
		private readonly TValue[] m_Target;

		public TValue[] Value { get; private set; }

		public readonly CustomEvent<TValue[]> OnValueChanged = new CustomEvent<TValue[]>();

		public AValueArrayTween(EasingFunc easing, TValue[] buffer, TValue[] source, TValue[] target)
			: base(easing)
		{
			m_Buffer = buffer;
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
			Blend(m_Buffer, m_Source, m_Target, progress, reverseBlend);
			OnValueChanged.Invoke(m_Buffer);
		}

		protected abstract void Blend(TValue[] buffer, TValue[] source, TValue[] target, float blend, float reverseBlend);
	}
}
