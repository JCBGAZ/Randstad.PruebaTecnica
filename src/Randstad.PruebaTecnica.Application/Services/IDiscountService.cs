
namespace Randstad.PruebaTecnica.Application.Services
{
    public interface IDiscountService
    {
        Task<decimal?> GetDiscountAsync(int productId);
    }
}
