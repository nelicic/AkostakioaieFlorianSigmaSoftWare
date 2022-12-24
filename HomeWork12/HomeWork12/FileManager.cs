namespace HomeWork12
{
    public class FileManager : IFileManager
    {
        public IEnumerable<User> GetUsers(string path)
        {
            string line = string.Empty;
            List<User> users = new();

            using (StreamReader streamReader = new StreamReader(path))
            {
                while (!streamReader.EndOfStream)
                {
                    Thread.Sleep(200);
                    line = streamReader.ReadLine(); 

                    if (line == null)
                        continue;

                    User? user = ParseUser(line);

                    if (user != null)
                        yield return user;
                }
            }

            yield break;
        }

        private User? ParseUser(string str)
        {
            string [] split = str.Split(" ");
            var fileLogger = FileLogger.GetInstance();

            if (split.Length != 6)
            {
                fileLogger.LogException($"Invalid user: {str}");
                return null;
            }

            bool isNameParsed = true;
            
            if (split[0] == string.Empty)
            {
                fileLogger.LogException($"Invalid user: {str}");
                isNameParsed = false;
            }

            bool isStatusParsed = int.TryParse(split[2], out int status);
            if (!(isStatusParsed && status >= 1 && status <= 3))
                fileLogger.LogException($"Invalid user: {str}");

            bool isAgeParsed = int.TryParse(split[1], out int age);
            if (!(isAgeParsed && age > 0 && age < 100))
                fileLogger.LogException($"Invalid user: {str}");

            bool isTimeParsed = true;
            TimeSpan _time = new TimeSpan();
            try
            {
                _time = TimeSpan.Parse(split[3]);
            }
            catch (FormatException ex)
            {
                FileLogger.GetInstance().LogException(ex.Message + "\n");
                isTimeParsed = false;
            }

            bool isXParsed = double.TryParse(split[4], out double x);
            bool isYParsed = double.TryParse(split[5], out double y);

            Point point = new Point();
            if (!isXParsed && !isYParsed)
                fileLogger.LogException($"Invalid user: {str}");
            else
                point = new Point(x, y);

            if (!(isTimeParsed || isAgeParsed || isTimeParsed || isNameParsed || isXParsed || isYParsed))
                return null;

            return new User(split[0], age, status, _time, point);
        }
    }
}
