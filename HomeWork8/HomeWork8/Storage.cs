namespace HomeWork8
{
    public class Storage
    {
        public readonly Dictionary<Product, int> products;
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
    }
}
