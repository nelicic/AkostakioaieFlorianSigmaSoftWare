using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    public class Appartment
    {
        public decimal KVPRICE { get; private set; } = 1.4M;
        public int AppartmentId { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        //знову повторюєте помилку
        public Dictionary<DateOnly, decimal> Accounting { get; set; }

        public Appartment(int id, string lastName, string address)
        {
            AppartmentId = id;
            LastName = lastName;
            Address = address;
            Accounting = new Dictionary<DateOnly, decimal>();
        }
        public void AddMonth(DateOnly date, decimal bill)
        {
            Accounting.Add(date, bill);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Appartment {AppartmentId} | Owner {LastName}\n");
            DateTime dateTime;
            foreach (var item in Accounting)
            {
                dateTime = new DateTime(2022, item.Key.Month, 1);
                sb.Append($"{dateTime.ToString("MMMM", CultureInfo.GetCultureInfo("en-en"))}\t");
                if (dateTime.Month != 2 && dateTime.Month != 11)
                    sb.Append("\t");
                
            }
            sb.Append("\n");
            foreach (var item in Accounting)
            {
                dateTime = new DateTime(2022, item.Key.Month, 1);
                sb.Append($"{dateTime.ToString("dd.MM.yyyy", CultureInfo.GetCultureInfo("en-en"))}\t");
            }
            sb.Append("\n");
            foreach (var item in Accounting)
            {
                sb.Append($"{item.Value}Kv\t\t");
                
            }
            sb.Append("\n");
            foreach (var item in Accounting)
            {
                sb.Append($"{(item.Value * KVPRICE).ToString("c")}\t\t");
            }
            sb.Append("\n");
            return sb.ToString();
        }
    }
}
