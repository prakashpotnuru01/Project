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
    [Route("api/[controller]")]
    public class CartController:ControllerBase
    {
        private readonly CartService Service;    //Controllers-->Services-->Interface-->Repository

        public CartController(CartService _Service)
        {
            Service=_Service;
        }
        [HttpGet("GetAllCarts")]
        public async Task<IActionResult> GetAllCarts()
        {
            try
            {
                var cart = await Service.GetAllCarts();
                if(cart!=null)
                {
                    return Ok(cart);
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }  
        }

        [HttpGet("GetCategoryById/{cartId}")]
        public async Task<IActionResult> GetCartById(int cartId)
        {
            try
            {
                var cart = await Service.GetCartById(cartId);
                if(cart!=null)
                {
                    return Ok(cart);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("AddCart")]
        public async Task<IActionResult> AddToCart(CartDTO cartDTO)
        {
            try
            {
                var cart = await Service.AddToCart(cartDTO);
                if(cart)
                {
                    return Ok("Added succesfully");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        
        [HttpDelete("DeleteCart/{cartId}")]
        public async Task<IActionResult> DeleteCart(int cartId)
        {
            try
            {
                bool result = await Service.DeleteCart(cartId);
                if(result)
                {
                    return Ok("Cart Deleted Succesfully");
                }
                else{
                    return NotFound("Cart not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }  
        }
    }
}