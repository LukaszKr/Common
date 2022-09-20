using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ProceduralLevel.Common.BitMask;

namespace PerformanceTests.BitMask
{
	[Orderer(SummaryOrderPolicy.Method)]
	public class BitMaskPerformanceTests
	{
		[Benchmark]
		public void PerformaceSet()
		{
			const int passes = 1000000;

			Stopwatch watch = new Stopwatch();
			watch.Restart();
			for(int x = 0; x < passes; ++x)
			{
				BitMask128 mask = new BitMask128();
				for(int y = 0; y < BitMask128.LENGTH; ++y)
				{
					mask.Set(y);
				}
			}
		}

		[Benchmark]
		public void PerformaceContains()
		{
			const int passes = 100000000;

			Stopwatch watch = new Stopwatch();
			BitMask128 maskA = new BitMask128();
			BitMask128 maskB = new BitMask128();

			watch.Restart();
			for(int x = 0; x < passes; ++x)
			{
				maskA.Contains(maskB);
			}
		}

	}
}
