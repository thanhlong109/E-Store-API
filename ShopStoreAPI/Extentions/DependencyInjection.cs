using Application.Services.Implements;
using Application.Services.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository.Implements;
using Infrastructure.Repository.Interfaces;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace ShopStoreAPI.Extendtions
{
    public static class DependencyInjection
    {

        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ShopStoreDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
