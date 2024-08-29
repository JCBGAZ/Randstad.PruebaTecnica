using Microsoft.Extensions.DependencyInjection;
using Randstad.PruebaTecnica.Application.Services;

namespace Randstad.PruebaTecnica.Application
{
    public static class DependencyInjection
    {
        public static void AddServicesApplication(this IServiceCollection service)
        {
            service.AddScoped<IProductService, ProductService>();
            service.AddScoped<IDiscountService, DiscountMockApiService>();
            service.AddScoped<ProductStatusCache>();
        }
    }
}
