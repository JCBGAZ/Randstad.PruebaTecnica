using FluentValidation.Results;
using Moq;
using Randstad.PruebaTecnica.Application.DTOs.Product;
using Randstad.PruebaTecnica.Application.Services;

namespace Randstad.PruebaTecnica.UnitTesting.Mocks
{
    internal class MockProductSevices
    {
        public static Mock<IProductService> GetMock()
        {
            var mockService = new Mock<IProductService>();
            var productDTO = GetProducts();
            var listErrors = new List<ValidationFailure>();
            var productInsertOK = new ResponseProductSeInsert()
            {
                Description = "Test Ok",
                Name = "Product1",
                ProductId = 10
            };

            mockService.Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync((int id) => productDTO.FirstOrDefault(o => o.ProductId == id));

            mockService.Setup(s => s.ValidateInsert(It.IsAny<ProductInsertDTO>()))
                .ReturnsAsync((ProductInsertDTO dto) => {
                    if (dto.Stock < 0)
                        listErrors.Add(new ValidationFailure() { 
                            ErrorMessage = "'Stock' debe ser mayor o igual que '0'."
                        });

                    if (string.IsNullOrEmpty(dto.Name))
                        listErrors.Add(new ValidationFailure()
                        {
                            ErrorMessage = "Name is required"
                        });

                    if (dto.Price < 0)
                        listErrors.Add(new ValidationFailure()
                        {
                            ErrorMessage = "'Price' debe ser mayor que '0'."
                        });
                    return listErrors;
                });

            mockService.Setup(s => s.Insert(It.IsAny<ProductInsertDTO>()))
                .ReturnsAsync((ProductInsertDTO dto) => 
                {
                    return productInsertOK; 
                });

            mockService.Setup(s => s.ValidateUpdate(It.IsAny<ProductUpdateDTO>()))
                .ReturnsAsync((ProductUpdateDTO dto) => {
                    if (dto.Stock < 0)
                        listErrors.Add(new ValidationFailure()
                        {
                            ErrorMessage = "'Stock' debe ser mayor o igual que '0'."
                        });

                    if (string.IsNullOrEmpty(dto.Name))
                        listErrors.Add(new ValidationFailure()
                        {
                            ErrorMessage = "Name is required"
                        });

                    if (dto.Price < 0)
                        listErrors.Add(new ValidationFailure()
                        {
                            ErrorMessage = "'Price' debe ser mayor que '0'."
                        });
                    return listErrors;
                });

            mockService.Setup(s => s.Update(It.IsAny<ProductDTO>()));

            return mockService;
        }

        private static List<ProductDTO> GetProducts()
        {
            var products = new List<ProductDTO>() {
            new()
            {
                ProductId = 1,
                Name = "Laptop Asus",
                Discount = 41,
                Description = "Test",
                Price = 30,
                FinalPrice = 56,
                StatusName = "Active",
                Stock = 10
            },
            new()
            {
                 ProductId = 2,
                Name = "Laptop Hp",
                Discount = 20,
                Description = "Con windows 10",
                Price = 30,
                FinalPrice = 24,
                StatusName = "Inactive",
                Stock = 1
            },
            new()
            {
                ProductId = 3,
                Name = "Teclado",
                Discount = 10,
                Description = "Mecanico",
                Price = 30,
                FinalPrice = 56,
                StatusName = "Active",
                Stock = 10
            }};

            return products;
        }
    }
}
