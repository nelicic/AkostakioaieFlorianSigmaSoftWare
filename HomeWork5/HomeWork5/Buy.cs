namespace HomeWork5
{
    public class Buy
    {
        public Product Product { get; private set; }
        private int amount;
        public int Amount 
        {
            get => amount;
            set
            {
                amount = value;
                if (amount < 0)
                    amount = 0;
            }
        }

        public Buy()
        {
            Product = new Product();
            Amount = 0;
        }

        public Buy(Product product, uint amount)
        {
            Product = product.Clone() as Product ?? new Product();
            Amount = (int)amount;
        }

        public string ToString(Currency currency, WeightType weightType)
        {
            return $"{Product.ToString(currency, weightType)}\nAmount: {Amount}\n\n";
        }
    }
}
