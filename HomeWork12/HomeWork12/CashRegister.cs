namespace HomeWork12
{
    public class CashRegister
    {
        private static int _count = 1;
        public int Id { get; private set; }
        private Point _point;
        private PriorityQueue<User, int> _queue;
        public bool IsOpened { get; private set; } = true;

        public CashRegister(bool cashRegister)
        {
            Id = _count++;
            _point = Point.GetPoint(cashRegister);
            _queue = new PriorityQueue<User, int>();
        }

        public int QueueLength() => _queue.Count;
        public Point GetPosition() => _point;
        public void Enqueue(User user) => _queue.Enqueue(user, user.GetPriority());
        public User Dequeue() => _queue.Dequeue();
        public bool IsEmpty() => _queue.Count == 0;
        public void Close() => IsOpened = false;
        public void Open() => IsOpened = true;
        public List<User> GetList()
        {
            List<User> list = new List<User>();
            while (_queue.Count > 0)
                list.Add(_queue.Dequeue());

            return list;
        }

        public override string ToString()
        {
            return _point.ToString();
        }
    }
}
