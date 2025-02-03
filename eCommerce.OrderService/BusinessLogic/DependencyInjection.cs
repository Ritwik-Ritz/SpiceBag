
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic;

public static class DependencyInjection
{
    public static IServiceCollection AddBusinessLayer(this  IServiceCollection services, IConfiguration configuration)
    {

        return services;
    }
}
