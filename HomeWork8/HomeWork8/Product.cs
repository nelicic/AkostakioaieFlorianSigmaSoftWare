using System.Globalization;

namespace HomeWork8
{
    public class Product : IComparable, ICloneable
    {
        private string name = "<No name>";
        private decimal price;
        public string Name
        {
            get => name;
            set
            {
                if (value != null && value.Length > 0)
                    name = value;
                else
                    name = "<No name>";
            }
        }
        public decimal Price 
        {
            get => price;
            set
            {
                try
                {
                    if (value < 0)
                    {
                        price = 0;
                        throw new ArgumentOutOfRangeException(nameof(value));
                    }
                    price = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Price cannot be below zero!");
                }
            }
        }
        public Product()
        { }
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        public virtual void ChangePrice(int percent)
        {
            Price += (Price * percent) / 100.0m;
            Price = Math.Round(Price, 2);
        }
        public override string ToString()
        {
            return $"Name: {name}\nPrice: {Price:c}\n";
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Price);
        }
        public override bool Equals(object? obj)
        {
            if (obj is not Product item)
                return false;

            return (name == item.name && 
                Price == item.Price);
        }
        public int CompareTo(object? obj)
        {
            if (obj is not Product product)
                throw new ArgumentException();

            if (Price > product.Price)
                return 1;
            else if (Price < product.Price)
                return -1;
            return 0;
        }
        public object Clone() => MemberwiseClone();
    }
}
