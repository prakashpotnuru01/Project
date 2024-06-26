using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Identity.Client;
using ShoppingCart.DTO;
using ShoppingCart.Interfaces;
using ShoppingCart.Models;
using ShoppingCart.Services;

namespace ShoppingCart.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService Service;    //Controllers-->Services-->Interface-->Repository

        public UserController(UserService _Service)
        {
            Service=_Service;
        }
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var user = await Service.GetUsers();
                if(user!=null)
                {
                    return Ok(user);
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

        [HttpGet("GetUserById/{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            try
            {
                var user = await Service.GetUserById(userId);
                if(user!=null)
                {
                    return Ok(user);
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

        // [HttpPost("AddUser")]
        // public async Task<IActionResult> AddUser(UserDTO userDTO)
        // {
        //     try
        //     {
        //         var user = await Service.AddUser(userDTO);
        //         if(user!=null)
        //         {
        //             return Ok(user);
        //         }
        //         else
        //         {
        //             return BadRequest();
        //         }
        //     }
        //     catch(Exception ex)
        //     {
        //         return StatusCode(500, ex.Message);
        //     }
        // }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(int userId,UserDTO userDTO)
        {
            try
            {
                var user = await Service.UpdateUser(userId, userDTO);
                if(user!=null)
                {
                    return Ok(user);
                }
                return BadRequest();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }
        
        [HttpDelete("DeleteUser/{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            try
            {
                bool result = await Service.DeleteUser(userId);
                if(result)
                {
                    return Ok("User Deleted Succesfully");
                }
                else{
                    return NotFound("User not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }  
        }       
    }
}