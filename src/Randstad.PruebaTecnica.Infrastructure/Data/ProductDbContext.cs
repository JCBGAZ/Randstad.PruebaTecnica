using Microsoft.EntityFrameworkCore;
using Randstad.PruebaTecnica.Domain.Entity;

namespace Randstad.PruebaTecnica.Infrastructure.Data
{
    public class ProductDbContext(DbContextOptions<ProductDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductDbContext).Assembly);
        }
    }
}
