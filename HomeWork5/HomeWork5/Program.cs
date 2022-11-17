using HomeWork5;
//Ваші бали 90	140	85	90	90
// Homework1
Meat prod1 = new Meat("Mutton", 200, 1500, Quality.HighQuality, MeatType.Mutton);
Meat prod2 = new Meat("Mutton", 200, 1500, Quality.HighQuality, MeatType.Mutton);
DairyProduct prod3 = new DairyProduct("Milk", 30, 500, new DateOnly(2022, 11, 8));
Product prod4 = new Product("Cheese", 50, 0.4);

Cart cart = new Cart();

cart.AddToCart(prod1, 2);
cart.AddToCart(prod2, 3);
cart.AddToCart(prod3, 2);

cart.RemoveFromCart(prod2, 1);

Check.PrintCheck(cart, Currency.EUR, WeightType.KiloGrams);
