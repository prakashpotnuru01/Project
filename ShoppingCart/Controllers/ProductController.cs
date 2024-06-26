using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.DTO;
using ShoppingCart.Interfaces;
using ShoppingCart.Models;
using ShoppingCart.Services;

namespace ShoppingCart.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductController : ControllerBase
    {
        private readonly ProductService Service;

        public ProductController(ProductService _Service)
        {
            Service=_Service;
        }
        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            try{
                var products = await Service.GetProducts();
                if(products!=null)
                {
                    return Ok(products);
                }
                return NotFound();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(ProductDTO productDTO)
        {
            try{
                var product = await Service.AddProduct(productDTO);
                if(product!=null)
                {
                    return Ok(product);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
            
        }

        [HttpPut("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(int userId,ProductDTO productDTO)
        {
            try{
                var product = await Service.UpdateProduct(userId,productDTO);
                if(product!=null)
                {
                    return Ok(product);
                }
                return NotFound();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            try
            {
                var product = await Service.DeleteProduct(productId);
                if(product)
                {
                    return Ok("Deleted Successfully");
                }
                return NotFound();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }
    }
}