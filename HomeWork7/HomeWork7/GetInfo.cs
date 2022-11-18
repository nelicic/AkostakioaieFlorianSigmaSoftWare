using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7
{
    public static class GetInfo
    {
        public static Product GetProduct()
        {
            string str = string.Empty, squality = string.Empty, stype = string.Empty;
            decimal price;
            double weight;
            int year, month, day;
            MeatType type = MeatType.Pork;
            Quality quality = Quality.MediumQuality;
            DateOnly date;

            Console.WriteLine("What type of product do you want to add? " + nameof(DairyProduct) + " or " + nameof(Meat));
            str = Console.ReadLine() ?? "Dairy";
            if (str.ToLower() == "dairy")
            {
                Console.WriteLine("Input name, price, weight, expire date: year, month, day");
                str = Console.ReadLine() ?? "No name";
                price = Convert.ToInt32(Console.ReadLine());
                weight = Convert.ToInt32(Console.ReadLine());
                year = Convert.ToInt32(Console.ReadLine());
                month = Convert.ToInt32(Console.ReadLine());
                day = Convert.ToInt32(Console.ReadLine());
                date = new DateOnly(year, month, day);
                DairyProduct product = new DairyProduct(str, price, weight, date);
                return product;
            }
            else
            {
                Console.WriteLine("Input name, price, weight, quality (high/medium/low), meat type(mutton,chicken,veal,pork)");
                str = Console.ReadLine() ?? "No name";
                price = Convert.ToInt32(Console.ReadLine());
                weight = Convert.ToInt32(Console.ReadLine());

                squality = Console.ReadLine() ?? "medium";
                switch (squality.ToLower())
                {
                    case "high":
                        quality = Quality.HighQuality;
                        break;
                    case "medium":
                        quality = Quality.MediumQuality;
                        break;
                    case "low":
                        quality = Quality.LowQuality;
                        break;
                    default:
                        quality = Quality.MediumQuality;
                        break;
                }

                stype = Console.ReadLine() ?? "pork";
                switch (stype.ToLower())
                {
                    case "pork":
                        type = MeatType.Pork;
                        break;
                    case "veal":
                        type = MeatType.Veal;
                        break;
                    case "chicken":
                        type = MeatType.Chicken;
                        break;
                    case "mutton":
                        type = MeatType.Mutton;
                        break;
                    default:
                        type = MeatType.Pork;
                        break;
                }

                return new Meat(str, price, weight, quality, type);
            }
        }
    }
}
