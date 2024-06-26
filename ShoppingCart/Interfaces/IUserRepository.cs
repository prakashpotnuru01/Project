using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.DTO;
using ShoppingCart.Models;

namespace ShoppingCart.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDTO>> GetUsers();
        Task<UserDTO> GetUserById(int userId);
        // Task<bool> AddUser(UserDTO userDTO);
        Task<User> UpdateUser(int userId, UserDTO userDTO);
        Task<bool> DeleteUser(int userId);

    }
}