namespace HomeWork12
{
    public class User
    {
        private string _name = string.Empty;
        private int _age;
        private Status _status;
        public TimeSpan Time { get; private set; }
        private Point _point;

        public User(string name, int age, int status, TimeSpan time, Point point)
        {
            _name = name;
            _age = age;
            _point = point;
            _status = status == 3 ? (Status)status : status == 2 ? (Status)status : Status.Low; ;
            Time = time;
        }

        public Point GetPosition() => _point;
        public int GetPriority() => (int)_status + (Time < new TimeSpan(0, 30, 0) ? 0 : 1);

        public override string ToString()
        {
            return $"{_name} {_age} {_status} {Time} " + _point.ToString();
        }
    }
}
