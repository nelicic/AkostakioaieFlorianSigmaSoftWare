using HomeWork7;
using System.Globalization;

CultureInfo.CurrentCulture = new CultureInfo("en-US");
// Використовуйте неіменовані змінні. Швидку ініціалізацію.
Meat prod1 = new Meat("Mutton", 200, 1500, Quality.LowQuality, MeatType.Mutton);
Meat prod2 = new Meat("Mutton", 300, 1200, Quality.HighQuality, MeatType.Mutton);
DairyProduct prod3 = new DairyProduct("Milk", 30, 500, new DateOnly(2022, 11, 8));
Product prod4 = new Product("Cheese", 50, 0.4);

Storage storage1 = new Storage(new List<Product> { prod1, prod2, prod3, prod4 });

Storage storage2 = new Storage();
storage2.Add(prod4);
storage2.Add(prod1);

// generic GetProductsByType 
List<Product> products = storage1.GetProductsByType<Meat>();
foreach (Product product in products)
    Console.WriteLine(product + "\n");



// Homework 7 (class Storage)
List<Product> prod = storage1.Union(storage2);
Console.WriteLine("Union");
foreach (Product product in prod)
    Console.WriteLine(product + "\n");
Console.WriteLine();
prod = storage1.Except(storage2);
Console.WriteLine("Except");
foreach (Product product in prod)
    Console.WriteLine(product + "\n");
Console.WriteLine();
prod = storage1.Intersect(storage2);
Console.WriteLine("Intersect");
foreach (Product product in prod)
    Console.WriteLine(product + "\n");





// Luna
string card_number;

// American Express
card_number = "378282246310005";
Luna luna1 = new Luna(card_number);
Console.WriteLine(luna1);

// MasterCard
card_number = "5555555555554444";
Luna luna2 = new Luna(card_number);
Console.WriteLine(luna2);

// Visa
card_number = "4222222222222";

Luna luna3 = new Luna(card_number);
Console.WriteLine(luna3);

