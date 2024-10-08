using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public List<Product> getAllProducts()
    {
        return _productDal.GetAll();
    }

    public List<Product> getAllByCategory(int categoryId)
    {
        return _productDal.GetAll(p=>p.CategoryID == categoryId);
    }

    public List<Product> getByUnitPrice(decimal minUnitPrice, decimal maxUnitPrice)
    {
        return _productDal.GetAll(p=> p.UnitPrice >= minUnitPrice && p.UnitPrice <= maxUnitPrice);
    }
}