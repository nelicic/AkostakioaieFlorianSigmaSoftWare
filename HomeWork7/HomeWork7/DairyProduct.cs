namespace HomeWork7
{
    public class DairyProduct : Product
    {
        private DateOnly date;

        public DateOnly Date 
        {
            get => date;
            private set => date = value;
        }

        public DairyProduct() : base()
        { }

        public DairyProduct(string name, decimal price, double weight,
            DateOnly date) : base(name, price, weight)
        {
            Date = date;
        }

        public override void ChangePrice(int percent)
        {
            base.ChangePrice(percent);

            DateTime ExpireDate = Date.ToDateTime(TimeOnly.MinValue);
            Price += Price * (int)Math.Round((ExpireDate - DateTime.Now).TotalDays, 1) / 100;
            Price = Math.Round(Price, 2);
        }

        public override bool Equals(object? obj)
        {
            var item = obj as DairyProduct;
            if (item == null || !base.Equals(item))
                return false;

            return Date == item.Date;
        }

        public override int GetHashCode()
        {
            int hash = base.GetHashCode();
            return hash * Date.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString() + "Date: " + Date;
        }
    }
}
