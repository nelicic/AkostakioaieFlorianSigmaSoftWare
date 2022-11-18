namespace HomeWork7
{
    public enum Quality
    {
        HighQuality = 12,
        LowQuality = 3,
        MediumQuality = 7
    }

    public enum MeatType
    {
        Mutton,
        Pork,
        Veal,
        Chicken
    }

    public class Meat : Product
    {
        private Quality category;
        private MeatType type;

        public Quality Category
        {
            get => category;
            set => category = value;
        }
        
        public MeatType Type
        {
            get => type;
            set => type = value;
        }

        public Meat() : base()
        { }

        public Meat(string name, decimal price, double weight,
            Quality quality, MeatType _type)
            : base(name, price, weight)
        {
            category = quality;
            type = _type;
        }

        public override void ChangePrice(int percent)
        {
            base.ChangePrice(percent);
            Price += Price * (int)Category / 100;
            Price = Math.Round(Price, 2);
        }

        public override string ToString()
        {
            return base.ToString() + "Quality: " + Category + "\nType: " + Type;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetHashCode();
            hashCode *= (Category, Type).GetHashCode();
            return hashCode;
        }

        public override bool Equals(object? obj)
        {
            var item = obj as Meat;
            if (item == null || !base.Equals(item))
                return false;
            return (Category == item.Category && Type == item.Type);
        }
    }
}
