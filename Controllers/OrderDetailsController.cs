using BETOnlineShopAPI.Models;
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
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        public OrderDetailsController(IOrderDetailsRepository orderDetailsRepository)
        {
            _orderDetailsRepository = orderDetailsRepository;  
        }
        [HttpGet]
        [Route("getallorderdetails")]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetOrderDetails()
        {
            try
            {
                return Ok(await _orderDetailsRepository.GetAllOrderDetails());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetOrderDetailsByOrderId(int id)
        {
            try
            {
                return Ok(await _orderDetailsRepository.GetOrderDetailsByOrderId(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }
    }
}
