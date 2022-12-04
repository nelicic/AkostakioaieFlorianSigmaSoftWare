using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8
{
    public interface IFileProvider
    {
        Dictionary<Product, int> GetProducts(string path);
        List<List<string>> GetAdjacentProducts(string path);
        List<Order> GetOrders(string path);
    }
}
