using BETOnlineShopAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETOnlineShopAPI.Controllers
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
        [Route("getallproducts")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            try
            {
                return Ok(await productRepository.GetAllProducts());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
            
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            try
            {
                var result = await productRepository.GetProductById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }
        [HttpPost]
        [Route("addproduct")]
        [Authorize]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            try
            {
                if (product == null) return BadRequest();
                var createdProduct = await productRepository.AddProduct(product);
                return CreatedAtAction(nameof(GetProductById),
                    new { id = createdProduct.Id }, createdProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to create record");
            }
        }
        [HttpPut("updateproduct")]
        [Authorize]
        public async Task<ActionResult<Product>> UpDateProduct(Product product)
        {
            try
            {
                if (product.Id==0) return BadRequest("Product mismatch");
                var productToUpdate = productRepository.GetProductById(product.Id);
                if (productToUpdate == null) return NotFound($"Product with id= {product.Id} not found");
                return await productRepository.UpDateProduct(product);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to update record");
            }
        }
        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {
                var productToDelete = productRepository.GetProductById(id);
                if (productToDelete == null) return NotFound($"Product with id= {id} not found");
                await productRepository.DeleteProduct(id);
                return Ok($"Product with id= {id} successfully deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to delete the record");
            }

        }
    }
}
