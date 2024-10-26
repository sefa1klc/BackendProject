using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface IProductService 
{
    IDataResult<List<Product>> GetAll();
    IDataResult<List<Product>> getAllByCategory(int categoryId);
    IDataResult<List<Product>> getByUnitPrice(decimal minUnitPrice, decimal maxUnitPrice);
    IDataResult<List<ProductDetailDto>> GetProductDetails();
    
    IDataResult<Product> GetById(int productId);
    
    IDataResult<List<Product>> GetProductsById(int categoryId);
    IResult Add(Product product);
    IResult Update(Product product);
    
    IResult AddTransactionalTest(Product product);
}