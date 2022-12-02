using System;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace benchmarks
{
	[MemoryDiagnoser]
	public class GVsP
	{
		private const int dataLength1 = 16;
		private const int dataLength2 = 64;
		private const int dataLength3 = 1024;

		private static readonly int[] array1 = new int[dataLength1];
		private static readonly int[] array2 = new int[dataLength2];
		private static readonly int[] array3 = new int[dataLength3];

		public GVsP()
		{
			// Generate inputs
			Random rng = new Random(Seed: 1337);

			for (int i = 0; i < dataLength1; i++)
			{
				array1[i] = rng.Next(int.MinValue, int.MaxValue);
			}
			
			for (int i = 0; i < dataLength2; i++)
			{
				array2[i] = rng.Next(int.MinValue, int.MaxValue);
			}

			for (int i = 0; i < dataLength3; i++)
			{
				array3[i] = rng.Next(int.MinValue, int.MaxValue);
			}
		}

	#region 16 bytes
		[Benchmark]
		public void G16Bytes() => NthElementGPLv2.PartialSort.nth_element(indexable: (int[])array1.Clone(), startIndex: 0, nthSmallest: 8, endIndex: array1.Length - 1);

		[Benchmark]
		public void P16Bytes() => NthElementPD.PartialSort.nth_element(indexable: (int[])array1.Clone(), startIndex: 0, nthSmallest: 8, endIndex: array1.Length - 1);

	#endregion // 16 bytes

	#region 64 bytes
		[Benchmark]
		public void G64Bytes() => NthElementGPLv2.PartialSort.nth_element(indexable: (int[])array2.Clone(), startIndex: 0, nthSmallest: 32, endIndex: array2.Length - 1);

		[Benchmark]
		public void P64Bytes() => NthElementPD.PartialSort.nth_element(indexable: (int[])array2.Clone(), startIndex: 0, nthSmallest: 32, endIndex: array2.Length - 1);

	#endregion // 64 bytes

	#region 1024 bytes
		[Benchmark]
		public void G1024Bytes() => NthElementGPLv2.PartialSort.nth_element(indexable: (int[])array3.Clone(), startIndex: 0, nthSmallest: 512, endIndex: array3.Length - 1);

		[Benchmark]
		public void P1024Bytes() => NthElementPD.PartialSort.nth_element(indexable: (int[])array3.Clone(), startIndex: 0, nthSmallest: 512, endIndex: array3.Length - 1);

	#endregion // 1024 bytes
	}

	class Program
	{
		static void Main(string[] args)
		{
			var summary = BenchmarkRunner.Run<GVsP>();
		}
	}
}
