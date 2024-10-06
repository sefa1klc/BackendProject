namespace Collections;

public class Program
{
    public static void Main(string[] args)
    {
        List<string> names = new List<string> { "Ali", "Veli", "Mehmet" };
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    } 
}