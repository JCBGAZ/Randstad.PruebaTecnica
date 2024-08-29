using FluentValidation.Results;
using Randstad.PruebaTecnica.Application.DTOs.Product;

namespace Randstad.PruebaTecnica.Application.Services
{
    public interface IProductService
    {
        Task<ResponseProductSeInsert> Insert(ProductInsertDTO product);
        Task Update(ProductDTO product);
        Task<ProductDTO?> GetById(int productId);
        Task<List<ValidationFailure>> ValidateUpdate(ProductUpdateDTO product);
        Task<List<ValidationFailure>> ValidateInsert(ProductInsertDTO product);
    }
}
