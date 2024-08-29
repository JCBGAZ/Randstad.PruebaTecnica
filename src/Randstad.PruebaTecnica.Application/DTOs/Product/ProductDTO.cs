namespace Randstad.PruebaTecnica.Application.DTOs.Product
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string StatusName { get; set; } = null!;
        public int Stock { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalPrice { get; set; }
    }
}
