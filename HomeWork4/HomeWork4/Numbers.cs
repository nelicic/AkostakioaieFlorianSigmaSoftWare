using System.Text;

namespace HomeWork4
{
    public class Numbers
    {
        private int[] array;

        public Numbers(int count)
        {
            Random random = new Random();
            array = new int[count];
            for (int i = 0; i < count; i++)
                array[i] = random.Next(1, 20);
        }

        public int this[int index]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }

        public void GetSequences(int numberOfSequences)
        {
            Dictionary<int, int> sequences = new Dictionary<int, int>();
            bool[] primary = new bool[array.Length];

            for (int i = 0; i < array.Length; ++i)
                primary[i] = IsPrimary(array[i]);

            int end, count, max, final;

            for (int j = 0; j < numberOfSequences; j++)
            {
                end = 0;
                count = 0;
                max = 0;
                final = 0;
                for (int i = 0; i < primary.Length; i++)
                {
                    if (primary[i])
                    {
                        ++count;
                        end = i;
                    }
                    else
                    {
                        if (count >= max)
                        {
                            max = count;
                            final = i;
                        }
                        count = 0;
                    }
                }
                int k = 0;
                sequences.Add(final - max, max);
                for (int i = final; k <= max; k++, i--)
                    primary[i] = false;
            }
// тут теж порушення принципів SOLID. У цьому методі не треба видруковувати
            for (int i = 0; i < primary.Length; i++)
            {
                if (sequences.ContainsKey(i))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    int fpoint = sequences[i];
                    for (int k = 0; k < fpoint; k++, i++)
                        Console.Write(array[i] + " ");
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(array[i] + " ");
            }
        }

        private static bool IsPrimary(int n)
        {// Прості числа визначено дуже не оптимально!!!
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0 || n % 2 == 0)
                    return false;
            }
            return true;
        }

        public void Frequency()
        {
            HashSet<int> set = new HashSet<int>(array);
            Console.WriteLine("\t    Frequency");
            foreach (int i in set)
                Console.Write(String.Format("{0,4}", i));
            Console.WriteLine();
            int count = 0;
            foreach (int i in set)
            {
                count = 0;
                foreach (int j in array)
                {
                    if (i == j)
                        count++;
                }
                Console.Write(String.Format("{0,4}", count));
            }
            Console.WriteLine();
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
                str.Append(array[i] + " ");
            return str.ToString();
        }
    }
}
