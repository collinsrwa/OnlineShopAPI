using BETOnlineShopAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedModels.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETOnlineShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeRepository productTypeRepository;
        public ProductTypeController(IProductTypeRepository productTypeRepository)
        {
            this.productTypeRepository = productTypeRepository; 
        }
        [HttpGet]
        [Route("getalltypes")]
        public async Task<ActionResult<IEnumerable<ProductType>>> GetAllProductTypes()
        {
            try
            {
                return Ok(await productTypeRepository.GetAllProductTypes());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
            
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductType>> GetProductTypeById(int id)
        {
            try
            {
                var result= await productTypeRepository.GetProductTypeById(id);
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
        [Route("addproducttype")]
        [Authorize]
        public async Task<ActionResult<ProductType>> AddProductType(ProductType productType)
        {
            try
            {
                if (productType == null) return BadRequest();
                var createdProductType = await productTypeRepository.AddProductType(productType);
                return CreatedAtAction(nameof(GetProductTypeById),
                    new { id = createdProductType.Id }, createdProductType);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to create record");
            }

        }
        [HttpPut("updateproducttype")]
        [Authorize]
        public async Task<ActionResult<ProductType>> UpDateProductType(ProductType productType)
        {
            try
            {
                if (productType.Id==0) return BadRequest("ProductType mismatch");
                var productTypeToUpdate = productTypeRepository.GetProductTypeById(productType.Id);
                if(productTypeToUpdate==null) return NotFound($"ProductType with id= {productType.Id} not found");
                return await productTypeRepository.UpDateProductType(productType);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to update record");
            }

        }
        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<ActionResult> DeleteProductType(int id)
        {
            try
            {
                var productTypeToDelete = productTypeRepository.GetProductTypeById(id);
                if (productTypeToDelete == null) return NotFound($"ProductType with id= {id} not found");
                await productTypeRepository.DeleteProductType(id);
                return Ok($"ProductType with id= {id} successfully deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to delete the record");
            }

        }
    }
}
