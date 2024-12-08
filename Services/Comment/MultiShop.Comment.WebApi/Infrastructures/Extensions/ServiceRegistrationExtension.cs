using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.WebApi.Contexts;
using MultiShop.Comment.WebApi.Repositories.Abstracts;
using MultiShop.Comment.WebApi.Repositories.Concretes;
using MultiShop.Comment.WebApi.Services.Abstracts;
using MultiShop.Comment.WebApi.Services.Concretes;

namespace MultiShop.Comment.WebApi.Infrastructures.Extensions
{
    public static class ServiceRegistrationExtension
    {
        public static void DbContextRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CommentContex>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("sqlconnection"));
            });
        }

        public static void RepositoryRegistration(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IUserCommentRepository, UserCommentRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
        }

        public static void ServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IUserCommentService, UserCommentService>();
            services.AddScoped<IContactService, ContactService>();
        }
    }
}
