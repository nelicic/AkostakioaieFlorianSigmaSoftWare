using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8
{
    public delegate void Display(string message);
    public class Shop
    {
        private readonly IFileProvider _fileProvider;
        private readonly Storage _storage;
        private readonly List<List<string>> _adjacent;
        private readonly List<Order> _orders;

        public event Display? Notify;

        public Shop(IFileProvider fileProvider, string prodPath, string adjPath)
        {
            _fileProvider = fileProvider;
            _storage = new Storage(_fileProvider.GetProducts(prodPath));
            _adjacent = _fileProvider.GetAdjacentProducts(adjPath);
            _orders = new();
        }

        public void GetOrders(string path)
        {
            List<Order> orders = _fileProvider.GetOrders(path);
            foreach (var order in orders)
                ProcessOrder(order);
        }

        public List<string>? GetAdjacentList(string productName)
        {
            foreach (var outter in _adjacent)
                if (outter.Contains(productName))
                    return outter;
            return null;
        }

        public string AdjacentString(string productName)
        {
            List<string>? adjacent = GetAdjacentList(productName);
            return string.Join(", ", adjacent!).Replace(", " + productName, "");
        }

        public void ProcessOrder(Order order)
        {
            int missing = 0;
            foreach (KeyValuePair<Product, int> item in _storage)
            {
                if (item.Key.Name == order.ProductName)
                {
                    if (item.Value < order.Amount)
                    {
                        string adjacentsProducts = AdjacentString(item.Key.Name);
                        missing = Math.Abs(order.Amount - item.Value);

                        Notify?.Invoke($"{order}\nWe have {item.Value} products of that type." +
                            $" {missing} missing products.\n" +
                            $"But you can chose adjacent products from that list:\n" +
                            $"{adjacentsProducts}\n");
                    }
                    else
                    {
                        _orders.Add(order);
                    }
                }
            }
        }
    }
}
