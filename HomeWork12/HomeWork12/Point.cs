namespace HomeWork12
{
    public class Point
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public Point()
        { }
        public Point(Point x)
        {
            X = x.X;
            Y = x.Y;
        }
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public static Point GetPoint(bool cashRgister = false)
        {
            Random random = new Random();
            return new Point(Math.Round(random.NextDouble() * 100, 2), cashRgister? 0 : Math.Round(random.NextDouble() * 100, 2));
        }
        public override string ToString()
        {
            return $"x = {X} y = {Y}";
        }

        public static Point NearestPoint(Point x, List<Point> y)
        {
            Point? nearest = null;
            double distance;
            double min = double.MaxValue;
            foreach (Point point in y)
            {
                distance = Math.Sqrt(Math.Pow(x.X - point.X, 2) + Math.Pow(x.Y - point.Y, 2));
                if (distance < min)
                {
                    min = distance;
                    nearest = point;
                }
            }

            return nearest!;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Point pObj)
                return (X == pObj.X && Y == pObj.Y);
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}
