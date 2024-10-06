namespace OOP_3;

//to log database
public class DatabaseLoggerService : ILoggerService
{
    public void Log()
    {
        Console.WriteLine("Logging to database");
    }
}

