using Entities.Concrete;

namespace Business.Abstract;

public interface IProductService
{
    List<Product> getAllProducts();
    List<Product> getAllByCategory(int categoryId);
    List<Product> getByUnitPrice(decimal minUnitPrice, decimal maxUnitPrice);
}