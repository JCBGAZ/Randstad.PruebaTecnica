using Randstad.PruebaTecnica.Domain.Entity;

namespace Randstad.PruebaTecnica.Application.DTOs.Product
{
    internal interface IProductBase
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public ProductStatus Status { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
