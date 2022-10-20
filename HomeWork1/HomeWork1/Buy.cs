namespace HomeWork1
{
    public class Buy
    {
        public Dictionary<Product, int> Product { get; set; }
        public DateTime DateTime { get; private set; } = DateTime.Now;

        public Buy()
        {
            Product = new Dictionary<Product, int>();
            DateTime = DateTime.Now;
        }

        public void AddToCart(Product product, int amount)
        {
            if (Product.ContainsKey(product))
                Product.Remove(product);

            Product.Add(product, amount);
        }

        public double Total()
        {
            double total = 0;
            foreach (var item in Product)
                total += item.Key.Price * item.Value;
            return total;
        }

        private double TotalForProduct(Product product, int amount)
        {
            return product.Price * amount;
        }

        public override string ToString()
        {
            string result = string.Empty;
            foreach (var item in Product)
            {
                result += $"\n{item.Key.ToString()}\n" + $"Amount: {item.Value}\n" +
                    $"Total: {TotalForProduct(item.Key, item.Value)}$\n--------------";
            }
            return result;
        }
    }
}
