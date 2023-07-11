using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.Extensions;
using OnlineShop.Api.Repositories.Contracts;
using OnlineShop.Models.DTO;

namespace OnlineShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetItems()
        {
            try
            {
                var products = await this.productRepository.GetItem();
                var productCategories = await this.productRepository.GetCategories();
                if (products == null || productCategories == null)
                {
                    return NotFound();
                }
                else
                {
                    var productDTOs = products.ConvertToDTO(productCategories);
                    return Ok(productDTOs);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDTO>> GetItem(int id)
        {
            try
            {
                var product = await this.productRepository.GetItem(id);
                if (product == null )
                {
                    return BadRequest();
                }
                else
                {   
                    var productCategory =  await this.productRepository.GetCategory(product.CategoryId);
                    var productDTO = product.ConvertToDTO(productCategory);
                    return Ok(productDTO);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }





    }
}
