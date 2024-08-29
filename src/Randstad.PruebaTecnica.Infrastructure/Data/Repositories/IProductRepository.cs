using Randstad.PruebaTecnica.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randstad.PruebaTecnica.Infrastructure.Data.Repositories
{
    public interface IProductRepository
    {
        Task<Product> Add(Product product);
        Task Edit(Product product);
        Task<Product?> GetById(int id);
        Task<List<Product>> GetAll();
        Task<Product?> GetByName(string prodcutName);
    }
}
