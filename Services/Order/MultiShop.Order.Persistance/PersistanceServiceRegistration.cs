using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Persistance.Context;
using MultiShop.Order.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Persistance
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("OrderDbConnectionString")));

            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IOrderingRepository, OrderingRepository>();

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

            return services;
        }
    }
}
