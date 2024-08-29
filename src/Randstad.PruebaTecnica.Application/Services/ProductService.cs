using Randstad.PruebaTecnica.Infrastructure.Data.Repositories;
using Randstad.PruebaTecnica.Application.Extension;
using FluentValidation.Results;
using Randstad.PruebaTecnica.Application.DTOs.Validatiosn;
using Randstad.PruebaTecnica.Application.DTOs.Product;
using FluentValidation;

namespace Randstad.PruebaTecnica.Application.Services
{
    public class ProductService(IProductRepository repository, IDiscountService discountService, ProductStatusCache productStatusCache) : IProductService
    {
        private readonly IProductRepository _repository = repository;
        private readonly IDiscountService _discountService = discountService;
        private readonly ProductStatusCache _productStatusCache = productStatusCache;

        public async Task<ResponseProductSeInsert> Insert(ProductInsertDTO product)
        {
            var productSave = await _repository.Add(product.ToProduct());
            return productSave.ToProductDTO();
        }

        public async Task<ProductDTO?> GetById(int productId)
        {
            var discount = await _discountService.GetDiscountAsync(productId) ?? 0;
            var productStatus = await _productStatusCache.GetProductStatusAsync();
            return (await _repository.GetById(productId))?.ToProductDTO(discount, productStatus);
        }

        public async Task Update(ProductDTO product)
        {
            await _repository.Edit(product.ToProduct());
        }

        public async Task<List<ValidationFailure>> ValidateUpdate(ProductUpdateDTO product)
        {
            var validator = new ProductUpdateValidator();
            var resultadoValidacion = await validator.ValidateAsync(product);

            return resultadoValidacion.Errors;
        }

        public async Task<List<ValidationFailure>> ValidateInsert(ProductInsertDTO product)
        {
            var validator = new ProductInsertValidator();
            var resultadoValidacion = await validator.ValidateAsync(product);

            return resultadoValidacion.Errors;
        }
    }
}
