using HomeWork1;
using System.Linq;

// Homework1
Product prod1 = new Product("Apple", 4, 0.2);
Product prod2 = new Product("Ball", 175, 1);
Product prod3 = new Product("Crisps", 30, 0.6);
Product prod4 = new Product("Table", 6, 10);
Product prod5 = new Product("Apple", 4, 0.5);
Product prod6 = new Product("Apple", 6, 4.2);
Product prod7 = new Product("zxvxzvda", 8, 2.2);
Product prod8 = new Product("Table", 1, 0.2);

List<Product> products = new List<Product>()
{
    prod1,
    prod2,
};

List<Product> products1 = new List<Product>()
{
    prod3,
    prod4,
};

var anonymusList = products.Select(x => new { Name1 = x.Name, Price1 = x.Price }).ToList();

var where = products.Where(x => x.Price > 100).ToList();

var orderBy = products.OrderBy(x => x.Name.Length).ThenBy(x => x.Price);

var groupBy = products.GroupBy(x => x.Name);

var groupByMultipleProperties = products.GroupBy(x => x.Name).GroupBy(x => x.Key);

var groupByQuery = from item in products group item by new { q1 = item.Name, q2 = item.Price };


/*foreach (var keyValue in groupByMultipleProperties)
{
    Console.WriteLine(keyValue.Key);
    foreach (var newKeyValue in keyValue)
        foreach (var item in newKeyValue)
        Console.WriteLine(item);
}
*/

/*int[] array1 = { 5, 3, 9, 4, 5, 7 }; 
int[] array2 = { 31, 12, 13, 7 };

var join = array1.Join(
    array2,
    first => first,
    second => second,
    (a, b) => a * b);

foreach (var item in join)
    Console.Write(item + " ");*/

/*var joinProducts = products.Join(
    products1,
    x => x.Name,
    y => y.Name,
    (a, b) => new { Name = a.Name, Price = (a.Price + b.Price) / 2 });

foreach (var anonymusProduct in joinProducts)
    Console.WriteLine(anonymusProduct.Name + " " + anonymusProduct.Price);*/

/*bool contains = products.Contains(prod4);
bool any = products.Any(x => x.Price > 100);
bool all = products.Where(x => x.Name == "Apple").All(x => x.Price == 4);

int[] number = { 1, 2, 3 };

int aggregation = number.Aggregate(10, (x, y) => x + y * y);
Console.WriteLine(aggregation);*/

var prices = products.GroupBy(x => x.Price).ToDictionary(key => key.Key, value => value.ToList());

var union = products.SelectMany(num => products1, (n, a) => new { n, a });
foreach (var product in union)
    Console.WriteLine(product);

/*
foreach (var item in prices)
{
    Console.WriteLine(item.Key);
    foreach (var item2 in item.Value)
        Console.WriteLine(item.Key + " " +item2);
}*/