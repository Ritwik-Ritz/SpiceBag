using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        //TODO: Add services to the IOC container
        services.AddTransient<IUsersService, UserService>();

        return services;
    }
}
