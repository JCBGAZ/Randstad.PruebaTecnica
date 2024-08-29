using LazyCache;
using Randstad.PruebaTecnica.Domain.Entity;
using Randstad.PruebaTecnica.Domain.Utils;

namespace Randstad.PruebaTecnica.Application.Services
{
    public class ProductStatusCache(IAppCache cache)
    {
        private readonly IAppCache _cache = cache;

        public async Task<Dictionary<int, string>> GetProductStatusAsync()
        {
            return await _cache.GetOrAddAsync("ProductStatus", 
                LoadProductStatus, TimeSpan.FromMinutes(SystemValuesConfiguration.TimeSpanCacheMinutes));
        }

        private async Task<Dictionary<int, string>> LoadProductStatus()
        {
            var dictionariStatus = Enum.GetValues(typeof(ProductStatus))
               .Cast<ProductStatus>()
               .ToDictionary(t => (int)t, t => t.ToString());

            return await Task.FromResult(dictionariStatus);
        }
    }
}
