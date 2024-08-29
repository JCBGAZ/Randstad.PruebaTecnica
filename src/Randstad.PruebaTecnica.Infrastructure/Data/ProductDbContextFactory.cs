using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Randstad.PruebaTecnica.Infrastructure.Data
{
    public class ProductDbContextFactory : IDesignTimeDbContextFactory<ProductDbContext>
    {
        public ProductDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProductDbContext>();
            optionsBuilder.UseSqlite("Data Source=ProductDatabase.db");

            return new ProductDbContext(optionsBuilder.Options);
        }
    }
}
