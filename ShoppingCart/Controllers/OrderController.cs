using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.DTO;
using ShoppingCart.Services;

namespace ShoppingCart.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class OrderController:ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("AddOrder")]
        public async Task<IActionResult> AddOrder(OrderDTO orderDTO)
        {
            try
            {
                bool order = await _orderService.AddOrder(orderDTO);
                if(order)
                {
                    return BadRequest("order not found");
                }
                return Ok("Added Successfully");
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var order = await _orderService.GetAllOrders();
                if(order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}