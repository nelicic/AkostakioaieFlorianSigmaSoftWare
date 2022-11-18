using HomeWork7;
using System.Globalization;

CultureInfo.CurrentCulture = new CultureInfo("en-US");

Meat prod1 = new Meat("Mutton", 200, 1500, Quality.HighQuality, MeatType.Mutton);
Meat prod2 = new Meat("Mutton", 200, 1500, Quality.HighQuality, MeatType.Mutton);
DairyProduct prod3 = new DairyProduct("Milk", 30, 500, new DateOnly(2022, 11, 8));
Product prod4 = new Product("Cheese", 50, 0.4);

Storage storage1 = new Storage(prod3, prod4);
Storage storage2 = new Storage(prod1, prod4);

/*List<Product> prod = storage1.Union(storage2);
foreach (Product product in prod)
    Console.WriteLine(product + "\n");*/




// Luna
string card_number;

// American Express
card_number = "378282246310005";

// MasterCard
card_number = "5555555555554444";

// Visa
card_number = "4222222222222";

Luna luna = new Luna(card_number);
Console.WriteLine(luna);



