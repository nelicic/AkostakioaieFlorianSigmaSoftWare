using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    public class Check
    {
        public static void PrintCheck(Buy goods)
        {
            Console.Write("Check\n--------------");
            Console.WriteLine(goods);
            Console.WriteLine($"Total: {goods.Total()}$\nTime: {goods.DateTime.ToString("f")}\n");
        }
    }
}
