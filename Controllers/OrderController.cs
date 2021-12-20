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
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;   
        }
        [HttpPost]
        [Route("addanorder")]
        [Authorize]
        public async Task<ActionResult> AddOrder(Order order)
        {
            try
            {
                if (order == null) return BadRequest();
                order.OrderNo = _orderRepository.GetOrderNumber();
                await _orderRepository.AddOrder(order);
                return Ok("Order successfully Created");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to create the order try again");
            }
        }
        [HttpGet]
        [Route("getallorders")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            try
            {
                return Ok(await _orderRepository.GetAllOrders());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to retrieve data from database try again");
            }
        }
        [HttpPut]
        [Route("updateOrder")]
        [Authorize]
        public async Task<ActionResult<Order>> UpDateOrder(Order order)
        {
            try
            {
                if (order.Id == 0) { return NotFound(); }
                return Ok(await _orderRepository.UpDateOrder(order));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to retrieve the order try again");
            }
        }
        [HttpGet]
        [Route("{id:int}")]
        [Authorize]
        public async Task<ActionResult<Order>> GetOrderId(int id)
        {
            try
            {
                if (id == 0) { return NotFound(); }
                return Ok(await _orderRepository.GetOrderId(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to retrieve the order try again");
            }
        }
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize]
        public async Task<ActionResult> DeleteOrder(Order order)
        {
            try
            {
                if (order.Id == 0) { return NotFound(); }
                if (_orderRepository.GetOrderId(order.Id) == null) { return NotFound(); }
                await _orderRepository.DeleteOrder(order.Id);
                return Ok($"Order with id= {order.Id} successfully deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to retrieve the order try again");
            }
        }
    }
}
