using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8
{
    public class ConsoleLogger : ILogger
    {
        public void Info(string message) => Console.WriteLine(message);
    }
}
