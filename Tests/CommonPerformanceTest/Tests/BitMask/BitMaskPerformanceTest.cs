using System.Diagnostics;
using NUnit.Framework;
using ProceduralLevel.Common.BitMask;

namespace PerformanceTests.BitMask
{
    [TestFixture]
    public class BitMaskPerformanceTest
    {
        [Test]
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
            TestContext.WriteLine($"128bitmask, {passes} passes, time elapsed: {watch.ElapsedMilliseconds}ms");
        }

        [Test]
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
            TestContext.WriteLine($"128bitmask, {passes} passes, time elapsed: {watch.ElapsedMilliseconds}ms");
        }

    }
}
