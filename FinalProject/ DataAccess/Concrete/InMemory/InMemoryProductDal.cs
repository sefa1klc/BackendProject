using System.Linq.Expressions;
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
            new Product{ProductID = 1, CategoryID = 1,ProductName = "Bardak", UnitPrice = 15,UnitsInStock = 15},
            new Product{ProductID = 1, CategoryID = 1,ProductName = "Kamera", UnitPrice = 100,UnitsInStock = 3},
            new Product{ProductID = 1, CategoryID = 1,ProductName = "Kalem", UnitPrice = 25,UnitsInStock = 60},
            new Product{ProductID = 1, CategoryID = 1,ProductName = "Defter", UnitPrice = 35,UnitsInStock = 25},
            new Product{ProductID = 1, CategoryID = 1,ProductName = "Fare", UnitPrice = 200,UnitsInStock = 5},
            new Product{ProductID = 1, CategoryID = 1,ProductName = "Tabak", UnitPrice = 50,UnitsInStock = 10},
            
        };
    }
    
    public List<Product> GetAll()
    {
        return _products;
    }

    public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
    {
        throw new NotImplementedException();
    }

    public Product Get(Expression<Func<Product, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public void Add(Product product)
    {
        _products.Add(product);
    }

    public void Delete(Product product)
    {
        //LINQ - Language Integrated Query
        //to find the reference
        Product? productToDelete = _products.SingleOrDefault(x => x.ProductID == product.ProductID);
        if(productToDelete != null) 
        {
            _products.Remove(productToDelete);
        }
    }

    public void Update(Product product)
    {
        Product? productToUpdate = _products.SingleOrDefault(x => x.ProductID == product.ProductID);
        if (productToUpdate != null)
        {
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.CategoryID = product.CategoryID;
        }
    }

    public List<Product> GetAllByCategory(int categoryId)
    {
        return _products.Where(x => x.CategoryID == categoryId).ToList();
    }
}