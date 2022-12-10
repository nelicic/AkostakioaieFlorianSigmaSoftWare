using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9
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
        { 
            Random random = new Random();
            int length = random.Next(1, 10);

            StringBuilder str_build = new StringBuilder();
            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            Name = str_build.ToString();
            Weight = random.NextDouble() * 10;
            Price = (decimal)random.NextDouble() * 100;
        }

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

        public override string ToString()
        {
            return $"Name: {name}\nWeight: {weight}\nPrice: {Price:c}\n";
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
