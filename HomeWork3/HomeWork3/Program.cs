using HomeWork1;
using HomeWork3;


// Homework3
Product[] products = new Product[5];
products[0] = new DairyProduct("Milk", 40, 400, new DateOnly(2022, 11, 4));
products[1] = new Meat("Barbeque", 500, 1000, Quality.MediumQuality, MeatType.Pork);
products[2] = new DairyProduct("Butter", 20, 200, new DateOnly(2022, 12, 15));
products[3] = new Meat("Mutton Curry", 1200, 800, Quality.LowQuality, MeatType.Mutton);
products[4] = new Meat("Steak", 700, 350, Quality.HighQuality, MeatType.Veal);
Storage storage = new Storage(products);
storage.Display();

/*storage.ChangePriceBy(10);
storage.Display();

Console.WriteLine("\nProduct at index 3");
Console.WriteLine(storage[3]);*/
// ----------------

// HomeWork4
storage.SortByPrice(); // IComparable
storage.Display();

storage.SortByWeight(); // IComparer
storage.Display();


