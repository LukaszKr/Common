using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ProceduralLevel.Common.Ext;

namespace PerformanceTests.GridAccess
{
	[Orderer(SummaryOrderPolicy.FastestToSlowest)]
	public class GridAccessTests
	{
		private const int SIZE_X = 64;
		private const int SIZE_Y = 64;
		private const int SIZE_Z = 64;
		private const int PASSES = 100;

		[Benchmark(Baseline = true)]
		public void JaggedArrayIndexAccess()
		{
			int[][][] array = ArrayExt.Create<int>(SIZE_X, SIZE_Y, SIZE_Z);

			for(int pass = 0; pass < PASSES; ++pass)
			{
				for(int x = 0; x < SIZE_X; ++x)
				{
					for(int y = 0; y < SIZE_Y; ++y)
					{
						for(int z = 0; z < SIZE_Z; ++z)
						{
							array[x][y][z] = x+y+z;
						}
					}
				}
			}
		}

		[Benchmark]
		public void JaggedArrayLinearAccess()
		{
			int[][][] array = ArrayExt.Create<int>(SIZE_X, SIZE_Y, SIZE_Z);

			for(int pass = 0; pass < PASSES; ++pass)
			{
				for(int x = 0; x < array.Length; ++x)
				{
					int[][] xAxis = array[x];
					for(int y = 0; y < xAxis.Length; ++y)
					{
						int[] yAxis = xAxis[y];
						for(int z = 0; z < yAxis.Length; ++z)
						{
							yAxis[z] = x+y+z;
						}
					}
				}
			}
		}

		[Benchmark]
		public void SingleDimensionArrayLinearAccess()
		{
			int[] array = new int[SIZE_X*SIZE_Y*SIZE_Z];

			for(int pass = 0; pass < PASSES; ++pass)
			{
				for(int x = 0; x < array.Length; ++x)
				{
					array[x] = x;
				}
			}
		}

		[Benchmark]
		public void SingleDimensionArrayIndexAccess()
		{
			int[] array = new int[SIZE_X*SIZE_Y*SIZE_Z];

			for(int pass = 0; pass < PASSES; ++pass)
			{
				for(int x = 0; x < SIZE_X; ++x)
				{
					for(int y = 0; y < SIZE_Y; ++y)
					{
						for(int z = 0; z < SIZE_Z; ++z)
						{
							int index = (z*SIZE_X*SIZE_Y)+(y*SIZE_X)+x;
							array[index] = x+y+z;
						}
					}
				}
			}
		}

		//potentially slower due to memory misses?
		#region Reverse
		public void JaggedArrayIndexAccessReverse()
		{
			int[][][] array = ArrayExt.Create<int>(SIZE_X, SIZE_Y, SIZE_Z);

			for(int pass = 0; pass < PASSES; ++pass)
			{
				for(int x = SIZE_X-1; x >= 0; --x)
				{
					for(int y = SIZE_Y-1; y >= 0; --y)
					{
						for(int z = SIZE_Z-1; z >= 0; --z)
						{
							array[x][y][z] = x+y+z;
						}
					}
				}
			}
		}

		[Benchmark]
		public void JaggedArrayLinearAccessReverse()
		{
			int[][][] array = ArrayExt.Create<int>(SIZE_X, SIZE_Y, SIZE_Z);

			for(int pass = 0; pass < PASSES; ++pass)
			{
				for(int x = array.Length-1; x >= 0; --x)
				{
					int[][] xAxis = array[x];
					for(int y = xAxis.Length-1; y >= 0; --y)
					{
						int[] yAxis = xAxis[y];
						for(int z = yAxis.Length-1; z >= 0; --z)
						{
							yAxis[z] = x+y+z;
						}
					}
				}
			}
		}

		[Benchmark]
		public void SingleDimensionArrayLinearAccessReverse()
		{
			int[] array = new int[SIZE_X*SIZE_Y*SIZE_Z];

			for(int pass = 0; pass < PASSES; ++pass)
			{
				for(int x = array.Length-1; x >= 0; --x)
				{
					array[x] = x;
				}
			}
		}

		[Benchmark]
		public void SingleDimensionArrayIndexAccessReverse()
		{
			int[] array = new int[SIZE_X*SIZE_Y*SIZE_Z];

			for(int pass = 0; pass < PASSES; ++pass)
			{
				for(int x = SIZE_X-1; x >= 0; --x)
				{
					for(int y = SIZE_Y-1; y >= 0; --y)
					{
						for(int z = SIZE_Z-1; z >= 0; --z)
						{
							int index = (z*SIZE_X*SIZE_Y)+(y*SIZE_X)+x;
							array[index] = x+y+z;
						}
					}
				}
			}
		}

		#endregion
	}
}
