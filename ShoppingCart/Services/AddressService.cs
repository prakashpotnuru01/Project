using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.DTO;
using ShoppingCart.Interfaces;
using ShoppingCart.Models;

namespace ShoppingCart.Services
{
    public class AddressService
    {
        private readonly IAddressRepository _addressService;

        public AddressService(IAddressRepository addressService)
        {
            _addressService = addressService;
        }
        public async Task<bool> AddAddress(AddressDTO addressDTO)
        {
            try
            {
                return await _addressService.AddAddress(addressDTO);
            }
            catch (Exception)
            {
                throw;
            }  
        }

        public async Task<IEnumerable<AddressDTO>> GetAllAddress()
        {
            try
            {
                return await  _addressService.GetAllAddress();
            }
            catch (Exception)
            {
                throw;
            }  
        }

        public async Task<bool> DeleteAddress(int id)
        {
            try
            {
                return await _addressService.DeleteAddress(id);
            }
            catch (Exception)
            {
                throw;
            }   
        }

        public async Task<AddressDTO> EditAddress(int id,AddressDTO addressDTO)
        {
            try
            {
                return await _addressService.EditAddress(id,addressDTO);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<AddressDTO> GetAddressById(int id)
        {
            try
            {
                return await _addressService.GetAddressById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<AddressDTO> EditAddressAsync(int id,AddressDTO addressDTO)
        {
            try
            {
                return await _addressService.EditAddress(id,addressDTO);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}