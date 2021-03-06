﻿using System;
using System.Runtime.CompilerServices;

namespace ProceduralLevel.Common.Easing
{
	public static class EasingHelper
	{
		private const float HALF_PI = (float)Math.PI/2f;
		private const float DOUBLE_PI = (float)Math.PI*2f;
		private const float OVERSHOOT = 1.70158f;
		private const float OFFSET = 0.075f;

		private static readonly int METHOD_COUNT = EEasingTypeExt.MAX_VALUE+1;

		public delegate float EasingDelegate(float t);
		public static EasingDelegate[] Methods = new EasingDelegate[(EEasingMethodExt.MAX_VALUE+1)*METHOD_COUNT];

		static EasingHelper()
		{
			Register(EEasingMethod.Sine, SineIn);
			Register(EEasingMethod.Quad, QuadIn);
			Register(EEasingMethod.Cubic, CubicIn);
			Register(EEasingMethod.Quart, QuartIn);
			Register(EEasingMethod.Quint, QuintIn);
			Register(EEasingMethod.Expo, ExpoIn);
			Register(EEasingMethod.Circ, CircIn);
			Register(EEasingMethod.Back, BackIn);
			Register(EEasingMethod.Elastic, ElasticIn);
			Register(EEasingMethod.Bounce, BounceIn);
			Register(EEasingMethod.Linear, LinearIn);
		}

		private static void Register(EEasingMethod type, EasingDelegate inDelegate)
		{
			int index = ((int)type)*METHOD_COUNT;
			Methods[index] = inDelegate;
			Methods[index+1] = CreateOut(inDelegate);
			Methods[index+2] = CreateInOut(inDelegate);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static EasingDelegate Get(EEasingMethod type, EEasingType method)
		{
			return Methods[(int)type*METHOD_COUNT+(int)method];
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Calculate(EEasingMethod type, EEasingType method, float t)
		{
			return Methods[(int)type*METHOD_COUNT+(int)method](t);
		}

		#region Delegate generator
		private static EasingDelegate CreateOut(EasingDelegate inDelegate)
		{
			return (float t) => (1f-inDelegate(1f-t));
		}

		private static EasingDelegate CreateInOut(EasingDelegate inDelegate)
		{
			return (float t) =>
			{
				if(t < 0.5f)
				{
					return inDelegate(t*2f)*0.5f;
				}
				else
				{
					return 1f-inDelegate((1f-t)*2f)*0.5f;
				}
			};
		}
		#endregion

		#region Easing Methods
		private static float SineIn(float t)
		{
			return 1-(float)Math.Cos(t*HALF_PI);
		}

		private static float QuadIn(float t)
		{
			return t*t;
		}

		private static float CubicIn(float t)
		{
			return t*t*t;
		}

		private static float QuartIn(float t)
		{
			return t*t*t*t;
		}

		private static float QuintIn(float t)
		{
			return t*t*t*t*t*t;
		}

		private static float ExpoIn(float t)
		{
			return (float)Math.Pow(2f, 10*(--t));
		}

		private static float CircIn(float t)
		{
			return -1f*((float)Math.Sqrt(1f-t*t)-1f);
		}

		private static float BackIn(float t)
		{
			return 1f*t*t*((OVERSHOOT+1f)*t-OVERSHOOT);
		}

		private static float ElasticIn(float t)
		{
			if(t == 0) return 0;
			if(t == 1) return 1;

			float period = 0.3f;
			return -(float)(Math.Pow(2f, 10f*(t-=1f))*Math.Sin((t-OFFSET)*DOUBLE_PI/period));
		}

		//this was BounceOut, need to reverse it
		private static float BounceIn(float t)
		{
			t = 1f-t;
			float result = 0;
			if(t < 0.36363636363636365f)
			{
				result = 7.5625f*t*t;
			}
			else if(t < 0.7272727272727273f)
			{
				t = t-0.5454545454545454f;
				result = 7.5625f*t*t+0.75f;
			}
			else if(t < 0.9090909090909091f)
			{
				t = t-0.8181818181818182f;
				result = 7.5625f*t*t+0.9375f;
			}
			else
			{
				t = t - 0.9545454545454546f;
				result = 7.5625f*t*t+0.984375f;
			}
			return 1f-result;
		}

		private static float LinearIn(float t)
		{
			return t;
		}
		#endregion
	}
}
