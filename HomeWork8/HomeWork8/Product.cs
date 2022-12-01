namespace HomeWork8
{
    public class Product
    {
        public readonly string _name;
        public readonly decimal _price;
        public readonly int _amount;
        public Product(string name, decimal price, int amount)
        {
            _name = name;
            _price = price;
            _amount = amount;    
        }
    }
}
