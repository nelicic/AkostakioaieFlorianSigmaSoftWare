namespace HomeWork8
{
    public class Order
    {
        private string companyName;
        private string productName;
        private int amount;

        public string CompanyName
        {
            get => companyName;
            private set => companyName = value;
        }
        public string ProductName
        {
            get => productName;
            private set => productName = value;
        }
        public int Amount
        {
            get => amount;
            private set
            {
                amount = value > 0? value : 0;
            }
        }
        public Order(string cName, string pName, int amnt)
        {
            companyName = cName;
            productName = pName;
            amount = amnt;
        }
        public override string ToString()
        {
            return $"{CompanyName}\n{ProductName}\n{Amount}";
        }
    }
}
