using System.Globalization;

namespace HomeWork5
{
    public class Product : IComparable, ICloneable
    {
        private string name = "<No name>";
        private double weight;
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
        public double Weight 
        { 
            get => weight;
            set
            {
                try
                {
                    if (value < 0)
                    {
                        weight = 0;
                        throw new ArgumentOutOfRangeException(nameof(value));
                    }
                    weight = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Weight cannot be below zero!");
                }
            }
        }

        public Product()
        { }

        public Product(string name, decimal price, double weight)
        {
            Name = name;
            Weight = weight;
            Price = price;
        }

        public virtual void ChangePrice(int percent)
        {
            Price += (Price * percent) / 100.0m;
            Price = Math.Round(Price, 2);
        }

        public string ToString(Currency currency, WeightType weightType)
        {
            decimal currencyCoefficient = Check.GetCurrecyInfo(currency, out string culture);
            decimal weigthCoefficient = Check.GetWeightInfo(weightType);
            string weightMeasurement = weigthCoefficient == 1 ? "g" : "kg";
            decimal weight = (decimal)Weight * weigthCoefficient;
            var formatProvider = new CultureInfo(culture);
            return $"Name: {name}\nWeight: {weight.ToString("G29")} {weightMeasurement}\n" 
                + string.Format(formatProvider, "Price: {0:c}", Math.Round(Price * currencyCoefficient, 2));
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
                Weight == item.Weight && 
                Price == item.Price);
        }

        public int CompareTo(object? obj)
        {
            Product? product = obj as Product;
            if (product == null)
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
