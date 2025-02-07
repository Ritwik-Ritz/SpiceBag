
using BusinessLogic.Mappers;
using BusinessLogic.ServiceContracts;
using BusinessLogic.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic;

public static class DependencyInjection
{
    public static IServiceCollection AddBusinessLayer(this  IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IOrdersService, OrdersService>();
        services.AddAutoMapper(typeof(OrderAddRequestMapper).Assembly);


        return services;
    }
}
