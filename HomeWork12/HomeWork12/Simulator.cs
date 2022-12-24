using System.Diagnostics;

namespace HomeWork12
{
    public class Simulator
    {
        public List<CashRegister> CashRegisterList { get; set; }
        public Simulator(int count)
        {
            CashRegisterList = new();
            for (int i = 0; i < count; i++)
                CashRegisterList.Add(new CashRegister(true));
        }
        public void Main()
        {
            FileManager fm = new FileManager();
            var users = fm.GetUsers("E:\\C#\\SigmaSoftware\\HomeWork12\\HomeWork12\\Users.txt");

            foreach (var user in users)
            {
                EnqueueUser(user);
                Console.WriteLine(user);
            }

            StartTasks();
        }
        private List<User> CloseTheCashRegister(CashRegister cashRegister)
        {
            cashRegister.Close();
            List<User> list = cashRegister.GetList();

            return list;
        }

        private void StartTasks()
        {
            Task[] tasks = new Task[CashRegisterList.Count];

            for (int i = 0; i < tasks.Length; i++)
            {
                var currentCashRegister = CashRegisterList[i];
                tasks[i] = Task.Factory.StartNew(() => Process(currentCashRegister));
            }
            Task.WaitAll(tasks);

            var usersFromClosedCashRegister = CloseTheCashRegister(CashRegisterList[CashRegisterList.Count - 1]);

            foreach (var user in usersFromClosedCashRegister)
                EnqueueUser(user);

            tasks = new Task[CashRegisterList.Count];
            for (int i = 0; i < tasks.Length; i++)
            {
                var currentCashRegister = CashRegisterList[i];
                tasks[i] = Task.Factory.StartNew(() => ProcessAll(currentCashRegister));
            }
            Task.WaitAll(tasks);
        }

        private void Process(CashRegister cashRegister)
        {
            if (!cashRegister.IsOpened)
                return;

            FileLogger fileLogger = FileLogger.GetInstance();
            User userLeft = cashRegister.Dequeue();
            Stopwatch stopwatch = Stopwatch.StartNew();
            while (true)
            {
                if (stopwatch.ElapsedMilliseconds >= userLeft.Time.TotalMinutes * 20)
                    break;
            }
            fileLogger.LogUserAtCashRegister(userLeft, cashRegister, DateTime.Now, "Exiting");
        }

        private void ProcessAll(CashRegister cashRegister)
        {
            if (!cashRegister.IsOpened)
                return;

            FileLogger fileLogger = FileLogger.GetInstance();
            while (!cashRegister.IsEmpty())
            {
                User userLeft = cashRegister.Dequeue();
                Stopwatch stopwatch = Stopwatch.StartNew();
                while (true)
                {
                    if (stopwatch.ElapsedMilliseconds >= userLeft.Time.TotalMinutes * 20)
                        break;
                }
                fileLogger.LogUserAtCashRegister(userLeft, cashRegister, DateTime.Now, "Exiting");
            }
        }

        private void EnqueueUser(User user)
        {
            int minQueueLength = CashRegisterList.Where(x => x.IsOpened).Min(x => x.QueueLength());

            List<Point> cashRegisterPositionList = CashRegisterList
                .Where(x => x.IsOpened && x.QueueLength() == minQueueLength)
                .Select(x => new Point(x.GetPosition())).ToList();

            Point nearestPoint = Point.NearestPoint(user.GetPosition(), cashRegisterPositionList);

            var fileLogger = FileLogger.GetInstance();

            foreach (var item in CashRegisterList)
            {
                if (item.GetPosition().Equals(nearestPoint))
                {
                    item.Enqueue(user);
                    fileLogger.LogUserAtCashRegister(user, item, DateTime.Now, "Entering");
                }
            }
        }
    }
}
