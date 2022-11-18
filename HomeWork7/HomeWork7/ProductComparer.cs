namespace HomeWork7
{
    public class ProductComparer : IComparer<Product>
    {
        public int Compare(Product? x, Product? y)
        {
            if (x == null || y == null)
                throw new NullReferenceException();

            if (x.Weight > y.Weight)
                return 1;
            else if (x.Weight < y.Weight)
                return -1;
            return 0;
        }
    }
}
