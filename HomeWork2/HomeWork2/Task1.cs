using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    public enum SnakeType : byte
    {
        VerticalSnake,
        DiagonalSnake,
        SpiralSnkake
    }

    public class MyArray
    {
        public readonly int[,] array;
        private readonly int n;
        private readonly int m;

        public MyArray(int n, int m, SnakeType type)
        {
            this.n = n;
            this.m = m;

            if (type == SnakeType.DiagonalSnake)
                array = new int[n, n];
            else
                array = new int[n, m];


            switch (type)
            {
                case SnakeType.VerticalSnake:
                    VerticalInitialization();
                    break;
                case SnakeType.DiagonalSnake:
                    DiagonalInitialization();
                    break;
                case SnakeType.SpiralSnkake:
                    SpiralInitialization();
                    break;
                default:
                    break;
            }
        }

        private void VerticalInitialization()
        {
            int k = 1;
            int i = 0;
            for (int j = 0; j < m; j++)
            {//Можна зменшити кількість умов
                if (i == 0)
                    while (i < n)
                    {
                        array[i, j] = k++;
                        i++;
                    }
                else
                    while (i > 0)
                    {
                        i--;
                        array[i, j] = k++;
                    }
            }
        }

        private void DiagonalInitialization()
        {// теж можна оптимізувати
            int k = 1;
            int i = 0, j = 0;
            
            while (k < n * n + 1)
            {
                UpInitialization(ref k, ref i, ref j);
                DownInitialization(ref k, ref i, ref j);
            }

            void DownInitialization(ref int k, ref int i, ref int j)
            {
                while (!(i == n) && !(j < 0))
                {
                    array[i, j] = k++;
                    j--;
                    i++;
                } j++;

                if (i == n)
                {
                    i--;
                    j++;
                }
            }

            void UpInitialization(ref int k, ref int i, ref int j)
            {
                while (!(i < 0) && !(j == n))
                {
                    array[i, j] = k++;
                    j++;
                    i--;
                } i++;

                if (j == n)
                {
                    i++;
                    j--;
                }
            }
        }

        private void SpiralInitialization()
        {
            int k = 1;
            int i = 0, j = 0;
            int a = n, b = m - 1;

            while (k < n * m + 1)
            {
                if (a < 0 || b < 0)
                    return;
                Down(ref k, ref i, ref j);
                if (a < 0 || b < 0)
                    return;
                Right(ref k, ref i, ref j);
                if (a < 0 || b < 0)
                    return;
                Up(ref k, ref i, ref j);
                if (a < 0 || b < 0)
                    return;
                Left(ref k, ref i, ref j);
            }

            void Down(ref int k, ref int i, ref int j)
            {
                for (int count = 0; count < a; count++)
                {
                    array[i++, j] = k++;
                }
                j++;
                i--;
                a--;
            }

            void Up(ref int k, ref int i, ref int j)
            {
                for (int count = 0; count < a; count++)
                {
                    array[i--, j] = k++;
                }
                i++;
                j--;
                a--;
            }

            void Right(ref int k, ref int i, ref int j)
            {
                for (int count = 0; count < b; count++)
                {
                    array[i, j++] = k++;
                }
                j--;
                i--;
                b--;
            }

            void Left(ref int k, ref int i, ref int j)
            {
                for (int count = 0; count < b; count++)
                {
                    array[i, j--] = k++;
                }
                j++;
                i++;
                b--;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    sb.Append(String.Format("{0,3}", array[i, j]));
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }
    }
//Але все дуже структуризовано! Молодець!
}
