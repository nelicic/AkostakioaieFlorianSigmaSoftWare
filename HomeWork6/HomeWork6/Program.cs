using HomeWork6;
using System.Globalization;

CultureInfo.CurrentCulture = new CultureInfo("en-US");

Accountant accountant = new Accountant("E:\\C#\\SigmaSoftware\\HomeWork6\\HomeWork6\\data.txt");

await accountant.FullReport(1);


await accountant.FullReport(2);
await accountant.FullReport(3);
await accountant.FullReport(4);

await accountant.ReportFor(4, 1);
await accountant.ReportFor(18, 2);
await accountant.ReportFor(19, 3);
await accountant.ReportFor(37, 4);
await accountant.ReportFor(91, 5);

await accountant.GetDays();

await accountant.ElectricityNotUsed(1);
await accountant.ElectricityNotUsed(2);
await accountant.ElectricityNotUsed(3);
await accountant.ElectricityNotUsed(4);
await accountant.ElectricityNotUsed(5);

Console.WriteLine(accountant.GetDebtor(1));
