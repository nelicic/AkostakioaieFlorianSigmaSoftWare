using HomeWork8;
using System.Globalization;
CultureInfo.CurrentCulture = new CultureInfo("en-US");

string product = "E:\\C#\\SigmaSoftware\\HomeWork8\\HomeWork8\\products.txt";
string adjacent = "E:\\C#\\SigmaSoftware\\HomeWork8\\HomeWork8\\adjacent.txt";
string orders = "E:\\C#\\SigmaSoftware\\HomeWork8\\HomeWork8\\Orders.txt";

Shop shop = new Shop(new FileProvider(), product, adjacent);

ConsoleLogger consoleLogger = new ConsoleLogger();
FileLogger fileLogger = new FileLogger("E:\\C#\\SigmaSoftware\\HomeWork8\\HomeWork8\\");

shop.Notify += consoleLogger.Info;
shop.GetOrders(orders);