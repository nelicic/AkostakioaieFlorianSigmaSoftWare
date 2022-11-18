using System.Globalization;
using System.Text;

namespace HomeWork7
{
    public enum Currency
    {
        GRN,
        EUR,
        USD
    }

    public enum WeightType
    {
        Grams,
        KiloGrams
    }

    public class Check
    {
        public static decimal GetCurrecyInfo(Currency currency, out string culture)
        {
            switch (currency)
            {
                case Currency.EUR:
                    culture = "de-DE";
                    return 0.028m;
                case Currency.USD:
                    culture = "en-US";
                    return 0.028m;
                default:
                    culture = "uk-UA";
                    return 1.0m;
            }
        }

        public static decimal GetWeightInfo(WeightType weightType)
        {
            switch (weightType)
            {
                case WeightType.KiloGrams:
                    return 0.001m;
                default:
                    return 1m;
            }
        }

        public static void PrintCheck(Cart cart,
            Currency currency = Currency.GRN,
            WeightType weightType = WeightType.Grams)
        {
            Console.OutputEncoding = Encoding.UTF8;
            decimal currencyCoeficient = GetCurrecyInfo(currency, out string culture);
            var formatProvider = new CultureInfo(culture);

            Console.Write("Check\n--------------\n");
            Console.WriteLine(cart.ToString(currency, weightType));
            Console.Write(string.Format(formatProvider, "{0:c}", cart.Total() * currencyCoeficient));
        }
    }
}
