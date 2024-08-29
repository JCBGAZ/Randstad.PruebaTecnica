using FluentValidation;
using Randstad.PruebaTecnica.Application.DTOs.Product;
using Randstad.PruebaTecnica.Domain.Utils;

namespace Randstad.PruebaTecnica.Application.DTOs.Validatiosn
{
    internal abstract class ProductValidatorBase<T> : AbstractValidator<T> where T : IProductBase
    {
        protected ProductValidatorBase()
        {
            RuleFor(product => product.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(ProductValuesConfiguration.NameMaximumLength);

            RuleFor(product => product.Description)
                .MaximumLength(ProductValuesConfiguration.DescriptionMaximumLength);

            RuleFor(product => product.Price)
                .GreaterThan(ProductValuesConfiguration.PriceGreaterThan);

            RuleFor(product => product.Stock)
                .GreaterThanOrEqualTo(ProductValuesConfiguration.StockGreaterThanOrEqualTo);

            RuleFor(product => product.Status)
                .IsInEnum()
                .WithMessage("Invalid product status.");
        }
    }
}
