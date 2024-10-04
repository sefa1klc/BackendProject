namespace BackendProject;

public class Product
{
    public int  ID { get; set; }
    public int CategoryID { get; set; }
    public string ProductName { get; set; }
    public double UnitPrice { get; set; }
    public int UnitInStock { get; set; }
}