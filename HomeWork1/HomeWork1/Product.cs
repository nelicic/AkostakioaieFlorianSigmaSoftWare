namespace HomeWork1
{
    public class Product : IComparable
    {
        private string name = string.Empty;
        private double weight;
        public double Price { get; set; }
        public double Weight 
        { 
            get => weight; 
            private set => weight = value; 
        }

        public Product()
        { }

        public Product(string name, double price, double weight)
        {
            this.name = name;
            this.weight = weight;
            Price = price;
        }

        public virtual void ChangePrice(int percent)
        {
            Price += (double)(Price * percent) / 100.0;
            Price = Math.Round(Price, 2);
        }

        public override string ToString()
        {
            return $"Name: {name}\nWeight: {weight}\nPrice: {Price}\n";
        }

        public override int GetHashCode()
        {
            return (name, weight, Price).GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            var item = obj as Product;
            if (item == null)
                return false;

            return (name == item.name && 
                weight == item.weight && 
                Price == item.Price);
        }

        public int CompareTo(object? obj)
        {
            Product product = obj as Product;
            if (product == null)
                throw new ArgumentException();

            if (Price > product.Price)
                return 1;
            else if (Price < product.Price)
                return -1;
            return 0;
        }
    }
}
