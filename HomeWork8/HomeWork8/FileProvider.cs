using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8
{
    public class FileProvider : IFileProvider
    {
        public Dictionary<Product, int> GetProducts(string path)
        {
            Dictionary<Product, int> products = new();
            List<string> list = File.ReadLines(path).ToList();
            
            foreach (string line in list)
                products.Add(ProductParse(line, out int amount), amount);

            return products;
        }
        public List<List<string>> GetAdjacentProducts(string path)
        {
            List<List<string>> products = new();
            List<string> list = File.ReadLines(path).ToList();

            foreach (var line in list)
                products.Add(line.Replace(" ", "").Split(",").ToList());

            return products;
        }
        public List<Order> GetOrders(string path)
        {
            List<Order> orders = new();
            List<string> list = File.ReadLines(path).ToList();

            foreach (var line in list)
                orders.Add(OrderParse(line));

            return orders;
        }
        private static Order OrderParse(string line)
        {
            string[] fields = line.Split(" ");

            if (!int.TryParse(fields[2], out int amount))
                amount = 0;

            return new Order(fields[0], fields[1], amount);
        }
        private static Product ProductParse(string line, out int amount)
        {
            string[] fields = line.Split(" ");

            if (!int.TryParse(fields[2], out amount) || 
                !decimal.TryParse(fields[1].Replace("$", ""), out decimal price))
            {
                amount = 0;
                price = 0;
            }

            return new Product() { Name = fields[0], Price = price };
        }
    }
}
