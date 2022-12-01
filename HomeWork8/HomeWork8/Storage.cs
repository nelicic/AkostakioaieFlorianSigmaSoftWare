namespace HomeWork8
{
    public class Storage
    {
        private List<Product> products;

        public void GetProducts(string path)
        {
            List<string> lines = File.ReadLines(path).ToList();

            foreach (string line in lines)
            {
                products.Add(Product.TryParse(line));
            }
        }
    }
}
