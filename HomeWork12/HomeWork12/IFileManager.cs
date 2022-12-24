namespace HomeWork12
{
    public interface IFileManager
    {
        IEnumerable<User> GetUsers(string path);
    }
}
