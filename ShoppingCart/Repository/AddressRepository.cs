using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.DTO;
using ShoppingCart.Interfaces;
using ShoppingCart.Models;
using ShoppingCart.Services;

namespace ShoppingCart.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ShoppingCartDbContext _context;

        public AddressRepository(ShoppingCartDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AddressDTO>> GetAllAddress()
        {
            try
            {
                List<Address> list = await  _context.Addresses.ToListAsync();
                List<AddressDTO> dtoaddress = new List<AddressDTO>();

                    foreach (var address in list)
                    {
                        AddressDTO addressDTO = AddressToAddressDTO(address);
                        dtoaddress.Add(addressDTO);
                    }
                    return dtoaddress;
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
                var address =await _context.Addresses.FirstOrDefaultAsync(c=>c.UserId == id);
                if(address !=null)
                {
                    return AddressToAddressDTO(address);
                }
                return null!;
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
                var updatedAddress = await _context.Addresses.FirstOrDefaultAsync(c=>c.UserId == id);
                if(updatedAddress != null)
                {
                    updatedAddress.StreetNumber=addressDTO.HouseNumber;
                    updatedAddress.StreetName=addressDTO.StreetName;
                    updatedAddress.City=addressDTO.City;
                    updatedAddress.State=addressDTO.State;
                    updatedAddress.Pincode=addressDTO.Pincode;
                    updatedAddress.UserId=addressDTO.UserId;
                    await _context.SaveChangesAsync();

                    return AddressToAddressDTO(updatedAddress);
                }
                return null!;
            }
            catch(Exception)
            {
                throw;
            }
        }
        public async Task<bool> AddAddress(AddressDTO addressDTO)
        {
            try
            {
                if(addressDTO==null)
                {
                    return false;
                }
                    Address address = AddressDTOToAddress(addressDTO);
                    _context.Addresses.Add(address);
                    await _context.SaveChangesAsync();
                    return true;
            }
            catch(Exception)
            {
                throw;
            }
        }
                
        public async Task<bool> DeleteAddress(int id)
        {
            try
            {
                var address = await  _context.Addresses.FirstOrDefaultAsync(c=>c.UserId == id);
                if(address != null)
                {
                    _context.Addresses.Remove(address);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public Address AddressDTOToAddress(AddressDTO addressDTO)
        {
            return new Address
            {
                UserId=addressDTO.UserId,
                StreetNumber=addressDTO.HouseNumber,
                StreetName=addressDTO.StreetName,
                City=addressDTO.City,
                State=addressDTO.State,
                Pincode=addressDTO.Pincode
            };
        }

        public AddressDTO AddressToAddressDTO(Address address)
        {
            return new AddressDTO
            {
                UserId=address.UserId,
                HouseNumber=address.StreetNumber,
                StreetName=address.StreetName,
                City=address.City,
                State=address.State,
                Pincode=address.Pincode
            };
        }
    }
}