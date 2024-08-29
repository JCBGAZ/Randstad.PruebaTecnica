namespace Randstad.PruebaTecnica.Application.DTOs.Product
{
    public class ResponseProductSeInsert
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
