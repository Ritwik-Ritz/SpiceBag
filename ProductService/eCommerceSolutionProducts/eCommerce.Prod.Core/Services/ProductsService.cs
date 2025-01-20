using AutoMapper;
using eCommerce.Prod.Core.DTO;
using eCommerce.Prod.Core.ServiceContracts;
using eCommerce.Prod.Service.Entities;
using eCommerce.Prod.Service.RepositoryContracts;
using System.Linq.Expressions;

namespace eCommerce.Prod.Core.Services;

public class ProductsService : IProductService
{

    private readonly IProductsRepository _repository;
    private readonly IMapper _mapper;

    public ProductsService(IProductsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<ProductResponse?> AddProduct(ProductAddRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteProduct(Guid productId)
    {
        return await _repository.DeleteProduct(productId);
    }

    public Task<ProductResponse?> GetProductByCondition(Expression<Func<Product, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<List<ProductResponse?>> GetProductByExpression(Expression<Func<Product, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<List<ProductResponse?>> GetProducts()
    {
        throw new NotImplementedException();
    }

    public Task<ProductResponse?> UpdateProduct(ProductUpdateRequest request)
    {
        throw new NotImplementedException();
    }
}
