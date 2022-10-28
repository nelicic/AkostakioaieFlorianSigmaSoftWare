using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    public class MatrixRGB
    { 
        private readonly ConsoleColor[,] matrix;

        public MatrixRGB(int n = 8)
        {
            
            Random r = new Random();
            Array bar = Enum.GetValues(typeof(ConsoleColor));

            matrix = new ConsoleColor[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    matrix[i, j] = (ConsoleColor)bar.GetValue(r.Next(0, 16));


            // for demonstration in case that we won't have any lines
            matrix[3, 3] = ConsoleColor.DarkRed;
            matrix[3, 4] = ConsoleColor.DarkRed;
            matrix[3, 5] = ConsoleColor.DarkRed;
        }

        public void Display()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.ForegroundColor = matrix[i, j];
                    Console.BackgroundColor = matrix[i, j];
                    Console.Write(String.Format("{0,3}", (int)matrix[i, j] + " "));
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            GetIndexes();
        }

        private void GetIndexes()
        {
            int j_start_res = 0, j_end_res = 0, length = 0, line_res = 0;
            int j_start = 0, j_end = 0, tmp = (int)matrix[0, 0];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (tmp == (int)matrix[i, j])
                    {
                        j_end = j;

                        if (j_end - j_start >= 1)
                        {
                            if (length <= j_end - j_start)
                            {
                                line_res = i;

                                length = j_end - j_start + 1;
                                j_end_res = j_end;
                                j_start_res = j_end_res - length + 1;
                            }
                        }
                    }
                    else
                    {
                        tmp = (int)matrix[i, j];
                        j_start = j;
                        j_end = j;
                    }
                }
            }

            Console.WriteLine("Start index: " + j_start_res);
            Console.WriteLine("End index: " + j_end_res);
            Console.WriteLine("Length: " + length);
            Console.WriteLine("Line: " + line_res);

        }
    }

}
