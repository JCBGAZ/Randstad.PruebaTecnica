using FluentValidation;
using Randstad.PruebaTecnica.Application.DTOs.Product;
using Randstad.PruebaTecnica.Domain.Utils;

namespace Randstad.PruebaTecnica.Application.DTOs.Validatiosn
{
    internal class ProductUpdateValidator : ProductValidatorBase<ProductUpdateDTO>
    {
        public ProductUpdateValidator()
        {
            RuleFor(product => product.ProductId).GreaterThan(ProductValuesConfiguration.ProductGreaterThan);
        }
    }
}
