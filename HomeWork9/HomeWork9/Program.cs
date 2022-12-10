using BenchmarkDotNet.Running;
using HomeWork9;
using System.Globalization;

CultureInfo.CurrentCulture = new CultureInfo("en-US");

FileSort fileSort = new FileSort("E:\\C#\\SigmaSoftware\\HomeWork9\\HomeWork9\\");
fileSort.Sort("data.txt");

// quickSort я перевіряв через BenchmarkDotNet
// прийшлось і в ньому розбиратись
// (дивіться скрін)
var result = BenchmarkRunner.Run<BenchMark>(new DebugConfig());
