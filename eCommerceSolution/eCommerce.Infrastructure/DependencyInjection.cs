using eCommerce.Core.RepositoryContracts;
using eCommerce.Services.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        //TODO: Add services to the IOC container

        services.AddSingleton<IUsersRepository, UsersRepository>();

        return services;
    }
}

