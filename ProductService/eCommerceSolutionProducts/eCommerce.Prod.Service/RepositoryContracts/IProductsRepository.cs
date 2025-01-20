
using eCommerce.Prod.Service.Entities;
using System.Linq.Expressions;

namespace eCommerce.Prod.Service.RepositoryContracts;

public interface IProductsRepository
{
    Task<IEnumerable<Product>> GetProducts();

    Task<IEnumerable<Product?>> GetProductsByExpression(Expression<Func<Product, bool>> expression);

    Task<Product?> GetProductByCondition(Expression<Func<Product, bool>> condition);

    Task<Product?> AddProduct(Product product);

    Task<Product?> UpdateProduct(Product product);

    Task<bool> DeleteProduct(Guid productId);
}
