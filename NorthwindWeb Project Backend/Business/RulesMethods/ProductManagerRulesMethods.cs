using Business.Abstract;
using Business.Abstract.RulesMethods;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.RulesMethods;

public class ProductManagerRulesMethods : IManagerRulesMethods
{
    IProductDal _productDal;
    ICategoryService _categoryService;
    
    public ProductManagerRulesMethods(IProductDal productDal, ICategoryService categoryService)
    {
        _productDal  = productDal;
        _categoryService = categoryService;
    }
    
    public IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
    {
        var categoryProductsCount = _productDal.GetAll(p=>p.CategoryID == categoryId).Count;
        if (categoryProductsCount >= 1000) return new ErrorResult(Messages.ProductCountOfCategory);
        return new SuccessResult();
    }

    public IResult CheckIfProductNameExist(string _productName)
    {
        var productName = _productDal.GetAll(p => p.ProductName == _productName).Any();
        if (productName) return new ErrorResult(Messages.ProductNameAlreadyExist);
        return new SuccessResult();
    }

    public IResult CheckIfCategoryLimitExceeded()
    {
        var _categoryNum = _categoryService.GetAll();
        if(_categoryNum.Data.Count >= 15) return new ErrorResult(Messages.CategoryLimitExceeded);
        return new SuccessResult();
    }
}