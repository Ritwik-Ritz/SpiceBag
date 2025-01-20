using eCommerce.Prod.Core.Mappers;
using eCommerce.Prod.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Prod.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {

        //although just one automapper is enough 
        services.AddAutoMapper(typeof(AddRequestToProduct).Assembly);
        services.AddAutoMapper(typeof(UpdateRequestToProduct).Assembly);
        services.AddAutoMapper(typeof(ProductToProductResponse).Assembly);

        services.AddValidatorsFromAssemblyContaining<ProductAddValidator>();
        services.AddValidatorsFromAssemblyContaining<ProductUpdateValidator>();

        return services;
    }
}
