
using eCommerce.Prod.Service.Context;
using eCommerce.Prod.Service.Repositories;
using eCommerce.Prod.Service.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Prod.Service;

public static class DependencyInjection
{
    public static IServiceCollection AddDataService (this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseMySQL(configuration.GetConnectionString("MysqlConnection")!);
        });

        services.AddScoped<IProductsRepository, ProductsRepository>(); 

        return services;
    }
}
