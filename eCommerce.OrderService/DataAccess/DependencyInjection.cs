using DataAccess.Repository;
using DataAccess.RepositoryContracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("Mongo")!;

        services.AddSingleton<IMongoClient>(new MongoClient(connectionString));

        services.AddScoped<IMongoDatabase>(provider =>
        {
            IMongoClient mongoclient = provider.GetRequiredService<IMongoClient>();
            return mongoclient.GetDatabase("OrdersDb");
        });

        services.AddScoped<IOrdersRepository, OrdersRepository>();
        return services;
    }
}
