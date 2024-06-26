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
    public class CategoryController:ControllerBase
    {
        private readonly CategoryService Service;    //Controllers-->Services-->Interface-->Repository

        public CategoryController(CategoryService _Service)
        {
            Service=_Service;
        }
        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var category = await Service.GetAllCategories();
                if(category!=null)
                {
                    return Ok(category);
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

        [HttpGet("GetCategoryById/{userId}")]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            try
            {
                var category = await Service.GetCategoryById(categoryId);
                if(category!=null)
                {
                    return Ok(category);
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

        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory(CategoryDTO categoryDTO)
        {
            try
            {
                var user = await Service.AddCategory(categoryDTO);
                if(user)
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

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(int categoryId,CategoryDTO categoryDTO)
        {
            try
            {
                var user = await Service.UpdateCategory(categoryId, categoryDTO);
                if(user!=null)
                {
                    return Ok(user);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
        [HttpDelete("DeleteUser/{userId}")]
        public async Task<IActionResult> DeleteUser(int categoryId)
        {
            try
            {
                bool result = await Service.DeleteUser(categoryId);
                if(result)
                {
                    return Ok("Category Deleted Succesfully");
                }
                else{
                    return NotFound("Category not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }  
        } 
    }
}