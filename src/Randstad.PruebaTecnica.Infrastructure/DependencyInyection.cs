using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Randstad.PruebaTecnica.Infrastructure.Data;
using Randstad.PruebaTecnica.Infrastructure.Data.Repositories;

namespace Randstad.PruebaTecnica.Infrastructure
{
    public static class DependencyInyection
    {
        public static void AddServicesInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("ProductConnection")));

            //Repositories
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
