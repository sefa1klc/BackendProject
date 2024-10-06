namespace OOP_3;

//to log text file
public class FileLoggerService : ILoggerService
{
    public void Log()
    {
        Console.WriteLine("Logging to File");
    }
}