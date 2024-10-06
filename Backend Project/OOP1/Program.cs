namespace BackendProject;

public class Program
{
    public static void Main(string[] args)
    {
        ProductManager productManager = new ProductManager();
        
        // the first form of identification
        Product product1 = new Product(); 
        product1.ID = 1;
        product1.CategoryID = 2;
        product1.ProductName = "Pizza";
        product1.UnitPrice = 1.99;
        product1.UnitInStock = 4;
        
        // the second form of identification
        Product product2 = new Product
        {
            ID = 2,
            CategoryID = 3,
            ProductName ="Hamburger",
            UnitInStock =5,
            UnitPrice = 4.99
        };
        
        productManager.Add(product1);
        productManager.Update(product2);
        
    } 
}