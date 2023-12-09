using BlazorShop.Api.Mappings;
using BlazorShop.Api.Repositories.Interfaces;
using BlazorShop.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.Api.Controllers
{
    [Route("/api[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
        {
            try
            {
                var products = await _productRepository.GetItems();
                if (products is null)
                {
                    return NotFound();
                }
                else
                {
                    var productsDto = products.ConvertProductsToDto();
                    return Ok(productsDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error aacessing Database");
            }

        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetItemById(int id)
        {
            try
            {
                var product = await _productRepository.GetItem(id);
                if (product is null)
                {
                    return NotFound("Product not Found");
                }
                else
                {
                    var productDto = product.ConvertProductToDto();
                    return Ok(productDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error aacessing Database");
            }
        }
        [HttpGet]
        [Route("GetItemsByCategory/{categoryId}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItemsByCategory(int categoryId)
        {
            try
            {
                var products = await _productRepository.GetItemsByCategory(categoryId);
                var productsDto = products.ConvertProductsToDto();
                return Ok(productsDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error aacessing Database");
            }
        }
    }
}
