namespace HomeWork12
{
    public interface ILogger
    {
        void LogException(string message);
        void LogUserAtCashRegister(User user, CashRegister cashRegister, DateTime time, string action);
    }
}
