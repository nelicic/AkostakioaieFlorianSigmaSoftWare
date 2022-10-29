namespace HomeWork1
{
    public class Product
    {
        private string name = String.Empty;
        private double weight;
        public double Price { get; set; }

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
    }
}
