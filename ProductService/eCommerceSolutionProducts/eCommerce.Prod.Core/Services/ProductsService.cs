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

    public async Task<ProductResponse?> AddProduct(ProductAddRequest request)
    {
        if(request == null) throw new ArgumentNullException(nameof(request));

        Product product = _mapper.Map<Product>(request);

        Product? addedProduct = await _repository.AddProduct(product);

        ProductResponse addedProductResponse = _mapper.Map<ProductResponse>(addedProduct);

        return addedProductResponse;
    }

    public async Task<bool> DeleteProduct(Guid productId)
    {
        return await _repository.DeleteProduct(productId);
    }

    public async Task<ProductResponse?> GetProductByCondition(Expression<Func<Product, bool>> expression)
    {
        Product? product = await _repository.GetProductByCondition(expression);
        ProductResponse? responseProduct = _mapper.Map<ProductResponse>(product);
        return responseProduct;
    }

    public async Task<List<ProductResponse?>> GetProductByExpression(Expression<Func<Product, bool>> expression)
    {
        List<Product?> products = (List<Product?>)await _repository.GetProductsByExpression(expression);

        var responseList = new List<ProductResponse?>();

        foreach(var product in products)
        {
            responseList.Add(_mapper.Map<ProductResponse?>(product));
        }

        return responseList;
    }

    public async Task<List<ProductResponse?>> GetProducts()
    {
        List<Product?> products = (List<Product?>)await _repository.GetProducts();

        var ProductResponseList = new List<ProductResponse?>();

        foreach (Product? product in products)
        {
            ProductResponseList.Add(_mapper.Map<ProductResponse>(product));
        }

        return ProductResponseList;
    }

    public async Task<ProductResponse?> UpdateProduct(ProductUpdateRequest request)
    {
        if(request == null || request.ProductId == Guid.Empty) throw new ArgumentNullException(nameof(request));

        Product productToBeUpdated  = _mapper.Map<Product>(request);
        Product? updatedProduct = await _repository.UpdateProduct(productToBeUpdated);

        ProductResponse updatedProductResponse = _mapper.Map<ProductResponse>(updatedProduct);
        return updatedProductResponse;
    }
}
