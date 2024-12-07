using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Contexts;
using MultiShop.Comment.Repositories.Abstracts;
using MultiShop.Comment.Repositories.Concretes;
using MultiShop.Comment.Services.Abstracts;
using MultiShop.Comment.Services.Concretes;

namespace MultiShop.Comment.Infrastructures.Extensions
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
