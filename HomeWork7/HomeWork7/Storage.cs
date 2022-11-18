namespace HomeWork7
{
    public class Storage
    {
        private List<Product> products;
        public Storage(List<Product> _products) => products = _products;
        public Storage() => products = new List<Product>();
        public Storage(int count)
        {
            products = new List<Product>(count);

            for (int i = 0; i < count; ++i)
            {
                Product prod = GetInfo.GetProduct();
                products.Add(prod);
            }
        }
        public Product? this[int id]
        {
            get
            {
                try
                {
                    return products[id];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
            set
            {
                try
                {
                    products[id] = value!;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void Add(Product prod) => products.Add(prod);
        public void Remove(Product prod) => products.Remove(prod);
        public void SortByPrice() => Array.Sort(products.ToArray());
        public void SortByWeight() => Array.Sort(products.ToArray(), new ProductComparer());
        public override string ToString()
        {
            string str = string.Empty;
            foreach (var product in products)
                str += product.ToString() + "\n\n";

            return str;
        }
        public void ChangePriceBy(int percent)
        {
            foreach (var product in products)
                product.ChangePrice(percent);
        }
        public List<Product> GetProductsByType<T>() where T : Product
        {
            List<Product> prods = new List<Product>();
            foreach (var product in products)
                if (product is T)
                    prods.Add(product);

            return prods;
        }
        // HomeWork 7
        public List<Product> Except(Storage storage)
            => products.Except(storage.products).ToList();
        public List<Product> Intersect(Storage storage)
            => products.Intersect(storage.products).ToList();
        public List<Product> Union(Storage storage)
            => products.Union(storage.products).ToList();
    }
}
