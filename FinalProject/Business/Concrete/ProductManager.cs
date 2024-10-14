using System.ComponentModel.DataAnnotations;
using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

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
        if (DateTime.Now.Hour == 12)
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

    [ValidationAspect(typeof(ProductValidator))]
    public IResult Add(Product product)
    {
        _productDal.Add(product);
        return new SuccessResult(Messages.ProductAdded);
    }
}