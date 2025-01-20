using eCommerce.Prod.Core.DTO;
using eCommerce.Prod.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Prod.Core.ServiceContracts;

public interface IProductService
{
    Task<List<ProductResponse?>> GetProducts();

    Task<List<ProductResponse?>> GetProductByExpression(Expression<Func<Product, bool>> expression);

    Task<ProductResponse?> GetProductByCondition(Expression<Func<Product, bool>> expression);

    Task<ProductResponse?> AddProduct(ProductAddRequest request);

    Task <ProductResponse?> UpdateProduct(ProductUpdateRequest request);

    Task<bool> DeleteProduct(Guid productId);
}
