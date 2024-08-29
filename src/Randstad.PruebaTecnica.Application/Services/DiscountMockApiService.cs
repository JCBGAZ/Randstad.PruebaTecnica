using Randstad.PruebaTecnica.Application.DTOs;
using System.Net.Http.Json;

namespace Randstad.PruebaTecnica.Application.Services
{
    public class DiscountMockApiService(HttpClient httpClient) : IDiscountService
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<decimal?> GetDiscountAsync(int productId)
        {
            var url = $"https://66cfd54b181d059277dc69b5.mockapi.io/api/products/{productId}";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var discount = await response.Content.ReadFromJsonAsync<ResponseDiscount>();
                return discount?.Discount;
            }

            return null;
        }
    }
}
