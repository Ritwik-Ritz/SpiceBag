using eCommerce.Prod.Service.Context;
using eCommerce.Prod.Service.Entities;
using eCommerce.Prod.Service.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eCommerce.Prod.Service.Repositories;

public  class ProductsRepository : IProductsRepository
{
    private readonly ApplicationDbContext _context;

    public ProductsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Product?> AddProduct(Product product)
    {
        _context.products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<bool> DeleteProduct(Guid productId)
    {
        Product? prod = await _context.products.FirstOrDefaultAsync(temp => temp.ProductId == productId);

        if (prod == null)
        {
            return false;
        }

        _context.products.Remove(prod);
        await _context.SaveChangesAsync();
        return true;
        
    }

    public async Task<Product?> GetProductByCondition(Expression<Func<Product, bool>> condition)
    {
        return await _context.products.FirstOrDefaultAsync(condition);
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _context.products.ToListAsync();
    }

    public async Task<IEnumerable<Product?>> GetProductsByExpression(Expression<Func<Product, bool>> condition)
    {
        return await _context.products.Where(condition).ToListAsync();
    }

    public async Task<Product?> UpdateProduct(Product product)
    {
        Product? prod = await _context.products.FirstOrDefaultAsync(temp => temp.ProductId == product.ProductId);

        if (prod == null)
        {
            return null;
        }

        prod.ProductName = product.ProductName;
        prod.UnitPrice = product.UnitPrice;
        prod.Quantity = product.Quantity;
        prod.Category = product.Category;

        await _context.SaveChangesAsync();

        return prod;

    }
}
