using Randstad.PruebaTecnica.Domain.Entity;

namespace Randstad.PruebaTecnica.Application.DTOs.Product
{
    public class ProductUpdateDTO : IProductBase
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public int Stock { get; set; }
        public string? Description { get; set; }
        public ProductStatus Status { get; set; }
        public decimal Price { get; set; }
    }
}
