namespace HomeWork9
{
    public class QuickSort
    {
        public Product[] SortArray(Product[] array, int leftIndex, int rightIndex, string pivotCheck)
        {
            var i = leftIndex;
            var j = rightIndex;
            Product pivot = new Product();

            if (pivotCheck == "left")
                pivot = array[leftIndex];
            else if (pivotCheck == "right")
                pivot = array[rightIndex];
            else
                pivot = array[new Random().Next(0, array.Length)];

            while (i <= j)
            {
                while (array[i].Price < pivot.Price)
                {
                    i++;
                }

                while (array[j].Price > pivot.Price)
                {
                    j--;
                }
                if (i <= j)
                {
                    Product temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                SortArray(array, leftIndex, j, pivotCheck);
            if (i < rightIndex)
                SortArray(array, i, rightIndex, pivotCheck);
            return array;
        }
    }
}
