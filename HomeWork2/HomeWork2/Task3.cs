using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    public class Cube
    {
        // vector with 6 matrix
        private readonly int [][,] data;
        private readonly int k;
        private readonly int n;
        private readonly int m;

        public Cube(int _k, int _n, int _m)
        {
            k = _k; 
            n = _n; 
            m = _m; 

            Random r = new Random();

            data = new int[k][,];
            for (int i = 0; i < k; i++)
                data[i] = new int[n, m];
            
            for (int i = 0; i < k; i++)
                for (int j = 0; j < n; j++)
                    for (int o = 0; o < m; o++)
                        data[i][j, o] = r.Next(0, 11) > 8 ? 0 : 1;
        }

        public void Display()
        {
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int o = 0; o < m; o++)
                    {
                        if (i % 2 == 0)
                        {
                            if (data[i][j, o] == 0 && data[i + 1][j, o] == 0)
                                Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(data[i][j, o] + " ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }

                        if (i % 2 != 0)
                        {
                            if (data[i][j, o] == 0 && data[i - 1][j, o] == 0)
                                Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(data[i][j, o] + " ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
