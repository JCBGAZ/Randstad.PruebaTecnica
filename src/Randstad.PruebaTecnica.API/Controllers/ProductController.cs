using Microsoft.AspNetCore.Mvc;
using Randstad.PruebaTecnica.Application.DTOs;
using Randstad.PruebaTecnica.Application.DTOs.Product;
using Randstad.PruebaTecnica.Application.Services;

namespace Randstad.PruebaTecnica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService service, ILogger<ProductController> logger) : ControllerBase
    {
        private readonly IProductService _service = service;
        private ILogger<ProductController> Logger { get; } = logger;

        [HttpPost("Insert")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage))] // Respuesta exitosa
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseMessage))] // Error 400 documentado
        public async Task<IActionResult> Post([FromBody] ProductInsertDTO product)
        {
            var response = new ResponseMessage();

            try
            {
                var erros = await _service.ValidateInsert(product);

                if (erros.Count > 0)
                {
                    response.Message = string.Join(", ", erros);
                    return BadRequest(response);
                }

                response.Data = await _service.Insert(product);
                response.Message = "The product was added successfully";
                return Ok(response);
            }
            catch (Exception ex)
            {
                Logger.LogError("{Message}", ex.Message);
                response.Message = "error when Insert product";
                return BadRequest(response);
            }
        }

        /// <summary>
        /// Actualiza un producto en la base de datos.
        /// </summary>
        /// <remarks>
        /// Esta operación valida que el producto con el <paramref name="productId"/> exista en la base de datos antes de proceder con la actualización. 
        /// Se debe proporcionar un objeto <see cref="ProductUpdateDTO"/> con la información actualizada del producto.
        /// </remarks>
        /// <param name="productId">Identificador único (ID) del producto a actualizar.</param>
        /// <param name="productDTO">Objeto que contiene los datos actualizados del producto.</param>
        /// <response code="200">OK. El producto fue actualizado correctamente en la base de datos.</response>
        /// <response code="400">Bad Request. Ocurrió una excepción no controlada o fallaron las validaciones del modelo.</response>
        /// <response code="404">Not Found. No se encontró el producto con el <paramref name="productId"/> especificado.</response>¿
        [HttpPut("Update/{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseMessage))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseMessage))]
        public async Task<IActionResult> Put(int productId, [FromBody] ProductUpdateDTO productDTO)
        {
            var response = new ResponseMessage();

            try
            {
                productDTO.ProductId = productId;
                var erros = await _service.ValidateUpdate(productDTO);

                if (erros.Count > 0)
                {
                    response.Message = string.Join(", ", erros);
                    return BadRequest(response);
                }

                var product = await _service.GetById(productId);

                if (product == null)
                {
                    response.Message = $"product not found: id {productId}";
                    return NotFound(response);
                }
                    
                product.Stock = productDTO.Stock;
                product.Price = productDTO.Price;
                product.Name = productDTO.Name;
                product.Description = productDTO.Description;
                await _service.Update(product);
                response.Message = "The product was updated successfully";
                return Ok(response);
            }
            catch (Exception ex)
            {
                Logger.LogError("{Message}", ex.Message);
                response.Message = $"There was an error updating the product, id {productId}";
                return BadRequest(response);
            }
        }

        [HttpGet("GetById/{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseMessage))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseMessage))] 
        public async Task<IActionResult> Get(int productId)
        {
            var response = new ResponseMessage();

            try
            {
                var product = await _service.GetById(productId);
                response.Data = product;

                if (product == null)
                {
                    response.Message = "product not found";
                    return NotFound(response);
                }
                else
                    response.Message = "product found";
                    return Ok(response);
            }
            catch (Exception ex)
            {
                Logger.LogError("{Message}", ex.Message);
                response.Message = "There was an error in obtaining the product";
                return BadRequest(response);
            }
        }
    }
}
