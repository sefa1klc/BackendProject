using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public IDataResult<List<Product>> GetAll()
    {
        if (DateTime.Now.Hour == 22)
        {
            return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
        }
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);
    }

    public IDataResult<List<Product>> getAllByCategory(int categoryId)
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryID == categoryId));
    }

    public IDataResult<List<Product>> getByUnitPrice(decimal minUnitPrice, decimal maxUnitPrice)
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=> p.UnitPrice >= minUnitPrice && p.UnitPrice <= maxUnitPrice));
    }

    public IDataResult<List<ProductDetailDto>> GetProductDetails()
    {
        return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
    }

    public IDataResult<Product> GetById(int productId)
    {
        return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductID == productId));
    }

    public IResult Add(Product product)
    {
        if (product.ProductName.Length < 2)
        {
            return new ErrorResult(Messages.ProductNameTooShort);
        }
        _productDal.Add(product);
        
        return new SuccessResult(Messages.ProductAdded);
    }
}