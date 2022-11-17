using System.Text;

namespace HomeWork5
{
    public class Cart
    {// Для пошуку зручніше використовувати словники
        private List<Buy> products;
        public Cart() => products = new();

        public Buy this [int id]
        {
            get => products[id];
        }

        public void AddToCart(Product product, uint amount)
        {
            if (amount == 0)
                return;

            foreach (Buy buy in products)
            {
                if (buy.Product.GetHashCode() == product.GetHashCode())
                {
                    buy.Amount += (int)amount;
                    return;
                }
            }
            products.Add(new Buy(product, amount));
        }

        public void RemoveFromCart(Product product, uint amount)
        {
            if (amount == 0)
                return;

            Buy removeBuy = new Buy();
            foreach (Buy buy in products)
            {
                if (buy.Product.GetHashCode() == product.GetHashCode())
                {
                    buy.Amount -= (int)amount;
                    removeBuy = buy;
                }
            }
// якщо немає такої кількості, як задано, треба організовувати Exception.
            if (removeBuy.Amount <= 0)
                products.Remove(removeBuy);
        }

        public decimal Total()
        {
            decimal charge = 0;
            foreach (Buy buy in products)
                charge += buy.Amount * buy.Product.Price;

            return Math.Round(charge, 2);
        }

        public string ToString(Currency currency, WeightType weightType)
        {
            StringBuilder str = new StringBuilder();
            foreach (Buy buy in products)
                str.Append(buy.ToString(currency, weightType));
            return str.ToString();
        }
    }
}
