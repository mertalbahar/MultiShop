using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.BusinessLayer.Concrete;
using MultiShop.Cargo.DataAccess.Abstract;
using MultiShop.Cargo.DataAccess.Concrete;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.Business.Infrastructure.Extensions.ServiceRegistration
{
    public static class ServiceRegistrationExtension
    {
        public static IServiceCollection AddDbRegistrationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CargoContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("CargoDbConnectionString"));
            });

            return services;
        }

        public static IServiceCollection AddRepositoryRegistrationService(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<ICargoCompanyRepository, EfCargoCompanyRepository>();
            services.AddScoped<ICargoCustomerRepository, EfCargoCustomerRepository>();
            services.AddScoped<ICargoDetailRepository, EfCargoDetailRepository>();
            services.AddScoped<ICargoOperationRepository, EfCargoOperationRepository>();

            return services;
        }

        public static IServiceCollection AddServiceRegistrationService(this IServiceCollection services)
        {
            services.AddScoped<ICargoCompanyService, CargoCompanyManager>();
            services.AddScoped<ICargoCustomerService, CargoCustomerManager>();
            services.AddScoped<ICargoDetailService, CargoDetailManager>();
            services.AddScoped<ICargoOperationService, CargoOperationManager>();

            return services;
        }
    }
}
