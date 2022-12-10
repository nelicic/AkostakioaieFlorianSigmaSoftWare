using BenchmarkDotNet.Running;
using HomeWork9;
using System.Globalization;

CultureInfo.CurrentCulture = new CultureInfo("en-US");

/*FileSort fileSort = new FileSort("E:\\C#\\SigmaSoftware\\HomeWork9\\HomeWork9\\");
fileSort.Sort("data.txt");*/

/*QuickSort quickSort = new QuickSort();
Product[] product = new Product[20];

for (int i = 0; i < product.Length; i++)
    product[i] = new Product();

product = quickSort.SortArray(product, 0, product.Length - 1, "random");

foreach (Product p in product)
    Console.WriteLine(p);*/

var result = BenchmarkRunner.Run<BenchMark>(new DebugConfig());
