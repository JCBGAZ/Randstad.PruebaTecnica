using Microsoft.EntityFrameworkCore;
using Randstad.PruebaTecnica.Domain.Entity;

namespace Randstad.PruebaTecnica.Infrastructure.Data.Repositories
{
    public class ProductRepository(ProductDbContext context) : IProductRepository
    {
        private readonly ProductDbContext context = context;

        public async Task<Product?> GetById(int id)
        {
            return await context.Set<Product>().AsNoTracking().FirstOrDefaultAsync(f => f.ProductId == id);
        }

        public async Task<List<Product>> GetAll()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Product> Add(Product product)
        {
            await context.Set<Product>().AddAsync(product);
            await context.SaveChangesAsync();

            return product;
        }

        public async Task Edit(Product product)
        {
            context.Entry(product).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<Product?> GetByName(string prodcutName)
        {
            return await context.Products.FirstOrDefaultAsync(i => i.Name == prodcutName);
        }
    }
}
