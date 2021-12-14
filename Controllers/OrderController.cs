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
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;   
        }
        [HttpPost]
        [Route("addanorder")]
        public async Task<ActionResult> AddOrder(Order order)
        {
            try
            {
                if (order == null) return BadRequest();
                order.OrderNo = orderRepository.GetOrderNumber();
                await orderRepository.AddOrder(order);
                return Ok("Order successfully Created");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to create the order try again");
            }
            
        }
    }
}
