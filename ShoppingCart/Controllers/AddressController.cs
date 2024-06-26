using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.DTO;
using ShoppingCart.Models;
using ShoppingCart.Services;

namespace ShoppingCart.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class AddressController: ControllerBase
    {
        private readonly AddressService _addressService;

        public AddressController(AddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet("GetAllAddress")]
        public async Task<IActionResult> GetAllAddress()
        {
            try
            {
                var address = await _addressService.GetAllAddress();
                if(address == null)
                {
                    return NotFound();
                }
                return Ok(address);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpGet("GetAddressByid/{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            try
            {
                AddressDTO address = await _addressService.GetAddressById(id);
                if(address == null)
                {
                    return NotFound();
                }
                return Ok(address);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpPost("AddAddress")]
        public async Task<IActionResult> AddAddress(AddressDTO addressDTO)
        {
            try
            {
                bool address = await _addressService.AddAddress(addressDTO);
                if(address)
                {
                    return BadRequest("Address not found");
                }
                return Ok("Added Successfully");
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpDelete("DeleteAddress/{id}")]
        public async Task<IActionResult> DeleteAddressAsync(int id)
        {
            try
            {
                var address = await _addressService.DeleteAddress(id);
                if(address)
                {
                    return BadRequest();
                }
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }
        [HttpPut("EditAddress")]
        public async Task<IActionResult> EditAddress(int id,AddressDTO addressDTO)
        {
            try
            {
                var updatedAddress = await _addressService.EditAddressAsync(id,addressDTO);
                if(updatedAddress != addressDTO)
                {
                    return Ok(addressDTO);
                }
                return BadRequest();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }
    }
}