using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Validators;

namespace HomeWork9
{
    [MemoryDiagnoser]
    public class BenchMark
    {
        QuickSort quickSort = new QuickSort();
        private static Product[] _collection;
        [Params(100, 1000, 10000)]
        public int Size { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _collection = new Product[Size];
            for (int i = 0; i < Size; i++) 
                _collection[i] = new Product();
        }

        [Benchmark]
        public Product[] QuickSortLeft()
        {
            return quickSort.SortArray(_collection, 0, _collection.Length - 1, "left");
        }

        [Benchmark]
        public Product[] QuickSortRight()
        {
            return quickSort.SortArray(_collection, 0, _collection.Length - 1, "right");
        }

        [Benchmark]
        public Product[] QuickSortRandom()
        {
            return quickSort.SortArray(_collection, 0, _collection.Length - 1, "random");
        }
    }

    public class DebugConfig : ManualConfig
    {
        public DebugConfig()
        {
            Add(JitOptimizationsValidator.DontFailOnError); // ALLOW NON-OPTIMIZED DLLS

            Add(DefaultConfig.Instance.GetLoggers().ToArray()); // manual config has no loggers by default
            Add(DefaultConfig.Instance.GetExporters().ToArray()); // manual config has no exporters by default
            Add(DefaultConfig.Instance.GetColumnProviders().ToArray()); // manual config has no columns by default
        }
    }
}
