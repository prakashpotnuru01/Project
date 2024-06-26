using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.DTO;
using ShoppingCart.Models;

namespace ShoppingCart.Interfaces
{
    public interface IAddressRepository
    {
        Task<IEnumerable<AddressDTO>> GetAllAddress();
        Task<AddressDTO> GetAddressById(int id);
        Task<AddressDTO> EditAddress(int id,AddressDTO address);
        Task<bool> AddAddress(AddressDTO adddressDTO);
        Task<bool> DeleteAddress(int id);
    }
}