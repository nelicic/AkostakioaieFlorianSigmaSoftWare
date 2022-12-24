using System.Text;

namespace HomeWork12
{
    public class FileLogger : ILogger
    {
        private static FileLogger? _instance;
        private static object locker = new object();
        private FileLogger() { }

        public static FileLogger GetInstance()
        {
            lock (locker)
            {
                if (_instance == null)
                    _instance = new FileLogger();
            }

            return _instance;
        }

        public async void LogException(string message)
        {
            using (FileStream fstream = new FileStream("E:\\C#\\SigmaSoftware\\HomeWork12\\HomeWork12\\Exceptions.txt", FileMode.Append))
            {
                byte[] buffer = Encoding.Default.GetBytes(message + "\n");
                await fstream.WriteAsync(buffer, 0, buffer.Length);
            }
        }

        public void LogUserAtCashRegister(User user, CashRegister cashRegister, DateTime time, string action)
        {
            lock(locker)
            {
                using (FileStream fstream = new FileStream($"E:\\C#\\SigmaSoftware\\HomeWork12\\HomeWork12\\{action}.txt", FileMode.Append))
                {
                    byte[] buffer = Encoding.Default.GetBytes($"User {action} at cash register {cashRegister.Id}\n" +
                        $"{user}\n" + $"That occurs at {time}\n\n");
                    fstream.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }
}
