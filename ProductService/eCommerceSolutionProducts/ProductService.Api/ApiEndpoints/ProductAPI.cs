using eCommerce.Prod.Core.DTO;
using eCommerce.Prod.Core.ServiceContracts;
using eCommerce.Prod.Core.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ProductService.Api.ApiEndpoints;

public static class ProductAPI
{
    public static IEndpointRouteBuilder MapProductAPI(this IEndpointRouteBuilder app)
    {

        //GET all products
        app.MapGet("/api/products", async (IProductService productService) =>
        {
            List<ProductResponse?> productResponses = await productService.GetProducts();

            return Results.Ok(productResponses);
        });

        //GET product by id
        app.MapGet("/api/products/{productId:guid}", async (IProductService productService, Guid productId) =>
        {
            ProductResponse? response = await productService.GetProductByCondition(temp => temp.ProductId == productId);

            return Results.Ok(response);
        });

        //GET products based on search
        app.MapGet("/api/products/search/{searchString}", async (IProductService productService, string searchString) =>
        {
            //StringComparison.OrdinalIgnoreCase is used to ignore case sensitivity
            List<ProductResponse?> response = await productService.GetProductByExpression(temp => temp.ProductName!=null && temp.ProductName.Contains(searchString, StringComparison.OrdinalIgnoreCase));

            return Results.Ok(response);
        });

        //app.MapGet("/api/products/search/{category}", async (IProductService productService, string category) =>
        //{
        //    //StringComparison.OrdinalIgnoreCase is used to ignore case sensitivity
        //    List<ProductResponse?> response = await productService.GetProductByExpression(temp => temp.Category != null && temp.Category.Contains(category, StringComparison.OrdinalIgnoreCase));

        //    return Results.Ok(response);
        //});

        app.MapPost("/api/products", async (IProductService productService, ProductAddRequest addRequest) =>
        {
            ProductResponse? response = await productService.AddProduct(addRequest);

            if (response != null)
            {
                return Results.Created($"/api/products/{response.ProductId}", response);
            }
            else
            {
                return Results.Problem("Error in adding product");
            }
        });

        app.MapPut("/api/products", async (IProductService productService, ProductUpdateRequest updateRequest) =>
        {
            ProductResponse? response = await productService.UpdateProduct(updateRequest);

            return Results.Ok(response);
        });

        app.MapDelete("/api/products/{productId:guid}", async (IProductService productService, Guid productId) =>
        {
            bool response = await productService.DeleteProduct(productId);

            return Results.Ok(response);
        });

        return app;
    }
}
