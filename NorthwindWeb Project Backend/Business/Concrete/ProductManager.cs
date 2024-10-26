using System.ComponentModel.DataAnnotations;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.RulesMethods;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Exception;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
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
    ProductManagerRulesMethods _productManagerRulesMethods;

    public ProductManager(IProductDal productDal, ProductManagerRulesMethods productManagerRulesMethods)
    {
        _productDal = productDal;
        _productManagerRulesMethods = productManagerRulesMethods;
    }

    [PerformanceAspect(5)]
    [CacheAspect]
    public IDataResult<List<Product>> GetAll()
    {
        // if (DateTime.Now.Hour == 12)
        // {
        //     return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
        // }
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

    [CacheAspect]
    public IDataResult<Product> GetById(int productId)
    {
        return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductID == productId));
    }

    public IDataResult<List<Product>> GetProductsById(int categoryId)
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryID == categoryId));
    }

    [CacheRemoveAspect("IProductService.Get")]
    [SecuredOperation("product.add")]
    [LogAspect(typeof(FileLogger))]
    [ValidationAspect(typeof(ProductValidator))]
    public IResult Add(Product product)
    {
        IResult result = BusinessRules.Run(
            _productManagerRulesMethods.CheckIfProductCountOfCategoryCorrect(product.CategoryID),
            _productManagerRulesMethods.CheckIfProductNameExist(product.ProductName),
            _productManagerRulesMethods.CheckIfCategoryLimitExceeded());
        
        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (result != null) return result;
        
        _productDal.Add(product);
        return new SuccessResult(Messages.ProductAdded);
    }
    
    [CacheRemoveAspect("IProductService.Get")]
    [ValidationAspect(typeof(ProductValidator))]
    public IResult Update(Product product)
    {
        // CheckIfProductCountOfCategoryCorrect(product.CategoryID);
        // CheckIfProductNameExist(product.ProductName);
        
        return new SuccessResult(Messages.ProductUpdated);
    }

    [TransactionScopeAspect]
    public IResult AddTransactionalTest(Product product)
    {
        _productDal.Update(product);
        _productDal.Add(product);
        return new SuccessResult(Messages.ProductUpdated);
    }
}