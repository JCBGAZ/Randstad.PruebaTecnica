using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randstad.PruebaTecnica.Domain.Entity
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public int Stock { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }
        public DateTime Date_Insert { get; set; }
    }
}
