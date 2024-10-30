using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistration).Assembly));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<GetAddressQueryHandler>();
        services.AddScoped<GetAddressByIdQueryHandler>();
        services.AddScoped<CreateAddressCommandHandler>();
        services.AddScoped<UpdateAddressCommandHandler>();
        services.AddScoped<RemoveAddressCommandHandler>();

        services.AddScoped<GetOrderDetailQueryHandler>();
        services.AddScoped<GetOrderDetailByIdQueryHandler>();
        services.AddScoped<CreateOrderDetailCommandHandler>();
        services.AddScoped<UpdateOrderDetailCommandHandler>();
        services.AddScoped<RemoveOrderDetailCommandHandler>();

        return services;
    }
}
