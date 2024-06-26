using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.DTO;
using ShoppingCart.Interfaces;
using ShoppingCart.Models;
using ShoppingCart.Repository;

namespace ShoppingCart.Services
{
    public class UserService 
    {
        IUserRepository IUser;
        public UserService(IUserRepository _IUser)
        {
            IUser=_IUser;
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            try
            {
                return await IUser.GetUsers();
            }
            catch(Exception)
            {
                throw;
            }
            
        }

        public async Task<UserDTO> GetUserById(int userId)
        {
            try{
                return await IUser.GetUserById(userId);
            }
            catch(Exception)
            {
                throw;
            }
            
        }

        // public async Task<bool> AddUser(UserDTO user)
        // {
        //     try{
        //         return await IUser.AddUser(user);
        //     }
        //     catch (Exception)
        //     {
        //         throw;
        //     }
            
        // }
        public async Task<User> UpdateUser(int userId, UserDTO user)
        {
            try
            {
                return await IUser.UpdateUser(userId,user);
            }
            catch(Exception)
            {
                throw;
            }
            
        }
        public async Task<bool> DeleteUser(int userId)
        {
            try
            {
                return await IUser.DeleteUser(userId);
            }
            catch(Exception)
            {
                throw;
            }
            
        }
        
    }
}