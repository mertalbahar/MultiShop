using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.Message.Business.Abstract;
using MultiShop.Message.Business.Concrete;
using MultiShop.Message.DataAccess.Abstract;
using MultiShop.Message.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Message.Business.Infrastructure.Extensions.ServiceRegistration
{
    public static class ServiceRegistrationExtension
    {
        public static IServiceCollection AddDbRegistrationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MessageContext>(opt =>
            {
                opt.UseNpgsql(configuration.GetConnectionString("MessageDbConnectionString"));
            });

            return services;
        }

        public static IServiceCollection AddRepositoryRegistrationService(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IUserMessageRepository, UserMessageRepository>();

            return services;
        }

        public static IServiceCollection AddServiceRegistrationService(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IUserMessageService, UserMessageService>();

            return services;
        }
    }
}
