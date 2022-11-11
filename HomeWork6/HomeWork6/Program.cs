using HomeWork6;
using System.Globalization;

CultureInfo.CurrentCulture = new CultureInfo("en-US");

await Accountant.FullReport("data.txt", 1);
await Accountant.FullReport("data.txt", 2);
await Accountant.FullReport("data.txt", 3);
await Accountant.FullReport("data.txt", 4);

await Accountant.ReportFor("data.txt", 4, 1);
await Accountant.ReportFor("data.txt", 18, 2);
await Accountant.ReportFor("data.txt", 19, 3);
await Accountant.ReportFor("data.txt", 37, 4);
await Accountant.ReportFor("data.txt", 91, 5);

/*List<int>? ids = Accountant.HaveNotUsedElectricityForQuarter("data.txt", 1);
if (ids is not null)
    foreach (var item in ids)
        Console.WriteLine(item);*/

/*Console.WriteLine(Accountant.GetDebtor("data.txt", 1));*/

Accountant.GetDays("data.txt");