using Business.Concrete;
using Business.RulesMethods;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace FinalProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();
            //CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var item in categoryManager.GetAll().Data)
            {
                Console.WriteLine(item.CategoryName);
            }
        }

        // private static void ProductTest()
        // {
        //     ProductManager productManager = new ProductManager(new EfProductDal());
        //
        //     var result = productManager.GetProductDetails();
        //     
        //     if (result.Success)
        //     {
        //         foreach (var item in result.Data)
        //         {
        //             Console.WriteLine(item.ProductName + "/" + item.CategoryName);
        //         }
        //     }
        //     else
        //     {
        //         Console.WriteLine(result.Message);
        //     }
        //    
        // }
    }
}
