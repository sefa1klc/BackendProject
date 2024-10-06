namespace OOP_3;

public class SmsLoggerService : ILoggerService
{
    public void Log()
    {
        Console.WriteLine("Sms logged");
    }
}