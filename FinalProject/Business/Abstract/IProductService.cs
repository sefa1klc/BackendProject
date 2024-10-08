using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface IProductService 
{
    List<Product> getAllProducts();
    List<Product> getAllByCategory(int categoryId);
    List<Product> getByUnitPrice(decimal minUnitPrice, decimal maxUnitPrice);
    public List<ProductDetailDto> GetProductDetails();
}