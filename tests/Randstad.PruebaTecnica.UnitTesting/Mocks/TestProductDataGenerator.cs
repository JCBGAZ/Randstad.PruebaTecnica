using Randstad.PruebaTecnica.Application.DTOs.Product;
using System.Collections;
using Randstad.PruebaTecnica.Domain.Entity;

namespace Randstad.PruebaTecnica.UnitTesting.Mocks
{
    internal class TestProductDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data =
        [
            [new ProductInsertDTO() { Name = "Inter core i7", Stock = -1, Price = 10, Status = ProductStatus.Inactive }, "'Stock' debe ser mayor o igual que '0'."],
            [new ProductInsertDTO() { Stock = 10, Price = 10, Status = ProductStatus.Inactive }, "Name is required"],
            [new ProductInsertDTO() { Name = "Inter core i7", Stock = 10, Price = -10 }, "'Price' debe ser mayor que '0'."]
        ];

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
