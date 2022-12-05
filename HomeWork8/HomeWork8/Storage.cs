using System.Collections;
using System.Collections.Generic;

namespace HomeWork8
{
    public class Storage : IEnumerable<KeyValuePair<Product, int>>
    {
        private readonly Dictionary<Product, int> products;
        public Storage() => products = new Dictionary<Product, int>();
        public Storage(Product product, int amount) : this() => Add(product, amount);
        public Storage(Dictionary<Product, int> _products) => products = _products;
        public void Add(Product prod, int amount) => products.Add(prod, amount);
        public void Remove(Product prod) => products.Remove(prod);
        public override string ToString()
        {
            string str = string.Empty;
            foreach (var product in products)
                str += product.Key.ToString() + product.Value + "\n\n";

            return str;
        }

        public IEnumerator GetEnumerator()
        {
            return products.GetEnumerator();
        }

        IEnumerator<KeyValuePair<Product, int>> IEnumerable<KeyValuePair<Product, int>>.GetEnumerator()
        {
            foreach (var p in products)
            {
                yield return p;
            }
        }
    }
}
