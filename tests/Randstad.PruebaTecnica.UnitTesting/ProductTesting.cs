using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Randstad.PruebaTecnica.API.Controllers;
using Randstad.PruebaTecnica.Application.DTOs;
using Randstad.PruebaTecnica.Application.DTOs.Product;
using Randstad.PruebaTecnica.UnitTesting.Mocks;

namespace Randstad.PruebaTecnica.UnitTesting
{
    public class ProductTesting 
    {
        private readonly ProductController _productController;

        public ProductTesting()
        {
            var logger = Mock.Of<ILogger<ProductController>>();
            var mockService = MockProductSevices.GetMock();
            _productController = new ProductController(mockService.Object, logger);
        }

        [Fact]
        public async Task Get_ProductById_When_Exist_Product()
        {
            var result = await _productController.Get(1);
            var objectResult = result as ObjectResult;

            var responseProduct = objectResult?.Value as ResponseMessage;

            Assert.NotNull(responseProduct?.Data);
            result.Should().BeOfType<OkObjectResult>();
            var prdoductDTO = responseProduct?.Data as ProductDTO;
            Assert.Equal("Laptop Asus", prdoductDTO?.Name);
            Assert.Equal("product found", responseProduct?.Message);
        }

        [Fact]
        public async Task Get_ProductById_When_NotExist_Product()
        {
            var result = await _productController.Get(5);

            var objectResult = result as ObjectResult;
            var responseProduct = objectResult?.Value as ResponseMessage;

            result.Should().BeOfType<NotFoundObjectResult>();
            Assert.Null(responseProduct?.Data);
        }

        [Fact]
        public async Task Post_ValidProduct_ReturnsOkResult()
        {
            var productInsertDto = new ProductInsertDTO { Name = "Product1", Price = 100, Stock = 10 };
            var result = await _productController.Post(productInsertDto) as OkObjectResult;
            var response = result?.Value as ResponseMessage;

            result.Should().NotBeNull();
            result?.StatusCode.Should().Be(200);
            Assert.Equal("The product was added successfully", response?.Message);
            (response?.Data as ResponseProductSeInsert)?.Name.Should().Be("Product1");
            (response?.Data as ResponseProductSeInsert)?.ProductId.Should().Be(10);
        }

        [Theory]
        [ClassData(typeof(TestProductDataGenerator))]
        public async Task Post_ValidProduct_Returns_Erros_BadResult(ProductInsertDTO product, string message)
        {
            var result = await _productController.Post(product) as BadRequestObjectResult;
            var response = result?.Value as ResponseMessage;

            result.Should().NotBeNull();
            result?.StatusCode.Should().Be(400);
            Assert.Equal(message, response?.Message);
        }

        [Fact]
        public async Task Put_ValidProduct_ReturnsOkResult()
        {
            var productId = 1;
            var productInsertDto = new ProductUpdateDTO {  Name = "Product1", Price = 100, Stock = 10 };
            var result = await _productController.Put(productId, productInsertDto) as OkObjectResult;
            var response = result?.Value as ResponseMessage;

            result.Should().NotBeNull();
            result?.StatusCode.Should().Be(200);
            Assert.Equal("The product was updated successfully", response?.Message);
            (response?.Data as ResponseProductSeInsert)?.Name.Should().Be("Product1");
            (response?.Data as ResponseProductSeInsert)?.ProductId.Should().Be(productId);
        }
    }
}