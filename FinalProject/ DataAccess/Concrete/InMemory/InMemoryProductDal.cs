using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory;

public class InMemoryProductDal : IProductDal
{
    List<Product> _products;

    public InMemoryProductDal()
    {
        _products = new List<Product>()
        {
            new Product{ProductId = 1, CategoryId = 1,ProductName = "Bardak", UnitPrice = 15,UnitInStock = 15},
            new Product{ProductId = 1, CategoryId = 1,ProductName = "Kamera", UnitPrice = 100,UnitInStock = 3},
            new Product{ProductId = 1, CategoryId = 1,ProductName = "Kalem", UnitPrice = 25,UnitInStock = 60},
            new Product{ProductId = 1, CategoryId = 1,ProductName = "Defter", UnitPrice = 35,UnitInStock = 25},
            new Product{ProductId = 1, CategoryId = 1,ProductName = "Fare", UnitPrice = 200,UnitInStock = 5},
            new Product{ProductId = 1, CategoryId = 1,ProductName = "Tabak", UnitPrice = 50,UnitInStock = 10},
            
        };
    }
    
    public List<Product> GetAll()
    {
        return _products;
    }

    public void Add(Product product)
    {
        _products.Add(product);
    }

    public void Delete(Product product)
    {
        //LINQ - Language Integrated Query
        //to find the reference
        Product? productToDelete = _products.SingleOrDefault(x => x.ProductId == product.ProductId);
        if(productToDelete != null) 
        {
            _products.Remove(productToDelete);
        }
    }

    public void Update(Product product)
    {
        Product? productToUpdate = _products.SingleOrDefault(x => x.ProductId == product.ProductId);
        if (productToUpdate != null)
        {
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitInStock = product.UnitInStock;
            productToUpdate.CategoryId = product.CategoryId;
        }
    }

    public List<Product> GetAllByCategory(int categoryId)
    {
        return _products.Where(x => x.CategoryId == categoryId).ToList();
    }
}