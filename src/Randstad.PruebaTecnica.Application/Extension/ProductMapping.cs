using Randstad.PruebaTecnica.Application.DTOs.Product;
using Randstad.PruebaTecnica.Domain.Entity;
using System.Diagnostics;

namespace Randstad.PruebaTecnica.Application.Extension
{
    public static class ProductMapping
    {
        public static Product ToProduct(this ProductDTO source)
        {
            var product = new Product()
            {
                ProductId = source.ProductId,
                Name = source.Name,
                Stock = source.Stock,
                Description = source.Description,
                Price = source.Price,
            };

            return product;
        }

        public static Product ToProduct(this ProductInsertDTO source)
        {
            var product = new Product()
            {
                Name = source.Name,
                Stock = source.Stock,
                Description = source.Description,
                Price = source.Price,
            };

            return product;
        }

        public static ProductDTO ToProductDTO(this Product source, decimal discount, Dictionary<int, string> productStatus)
        {
            return new ProductDTO()
            {
                ProductId = source.ProductId,
                Name = source.Name,
                Price = source.Price,
                Stock = source.Stock,
                StatusName = productStatus?.GetValueOrDefault(source.Status ? 1 : 0) ?? "",
                Description = source.Description,
                Discount = discount,
                FinalPrice = source.Price * (100 - discount) / 100
            };
        }

        public static ResponseProductSeInsert ToProductDTO(this Product source)
        {
            return new ResponseProductSeInsert()
            {
                ProductId = source.ProductId,
                Name = source.Name,
                Description = source.Description
            };
        }
    }
}
