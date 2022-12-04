using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8
{
    public class FileLogger : ILogger
    {
        private readonly string PATH;
        public FileLogger(string path) => PATH = path;
        public async void Info(string message)
        {
            using (StreamWriter writer = new StreamWriter($"{PATH}result.txt", true))
            {
                await writer.WriteLineAsync(message);
            }
        }
    }
}
