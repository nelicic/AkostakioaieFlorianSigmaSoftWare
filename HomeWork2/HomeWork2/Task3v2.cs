using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    public enum AxisEnum
    {
        X, Y, Z
    }
    public class Cube2_0
    {
        private int[,,] data;
        private int x;
        private HashSet<int> Axis;

        public Cube2_0(int x)
        { 
            Random random = new Random(4);
            this.x = x;
            data = new int[x, x, x];

            Axis = new();
            int C = 0;
            for (int i = 0; i < x; i++)
                for (int j = 0; j < x; j++)
                    for (int k = 0; k < x; k++)
                        data[i, j, k] = random.Next(0, 11) > 2? 0 : 1;
                        //data[i, j, k] = C++;
        }

        public void Check(AxisEnum axis)
        {
            int count = 0;
            int overAllCount = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    count = 0;
                    for (int k = 0; k < x; k++)
                    {
                        if (axis == AxisEnum.X)
                            if (data[i, j, k] == 0)
                                count++;

                        if (axis == AxisEnum.Y)
                            if (data[i, k, j] == 0)
                                count++;

                        if (axis == AxisEnum.Z)
                            if (data[k, i, j] == 0)
                                count++;

                        if (count == x)
                            Axis.Add(overAllCount);
                    }
                    overAllCount++;
                }
            }
        }

        public void Display(AxisEnum axis)
        {
            Check(axis);

            int overAllCount = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    for (int k = 0; k < x; k++)
                    {
                        if (axis == AxisEnum.Y)
                        {
                            if (Axis.Contains(overAllCount))
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write(String.Format("{0,3}", data[i, k, j]));
                        }

                        if (axis == AxisEnum.X)
                        {
                            if (Axis.Contains(overAllCount))
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write(String.Format("{0,3}", data[i, j, k]));
                        }

                        if (axis == AxisEnum.Z)
                        {
                            if (Axis.Contains(overAllCount))
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write(String.Format("{0,3}", data[k, i, j]));
                        }
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    Console.WriteLine();
                    overAllCount++;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Axis.Clear();
        }
    }
}
