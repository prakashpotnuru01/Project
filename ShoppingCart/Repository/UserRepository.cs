using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.DTO;
using ShoppingCart.Interfaces;
using ShoppingCart.Models;

namespace ShoppingCart.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ShoppingCartDbContext context;

        public UserRepository(ShoppingCartDbContext _context)
        {
            context=_context;
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {   
            try
            {
                List<User> list = await context.Users.ToListAsync();
                List<UserDTO> users = new List<UserDTO>();

                foreach (var user in list)
                {
                    UserDTO userDTO = UserToUserDTO(user);
                    users.Add(userDTO);
                }
                return users;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<UserDTO> GetUserById(int userId)
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(c=>c.UserId == userId);
                if(user!=null)
                {
                    return UserToUserDTO(user);
                }
                return null!;
            }
            catch(Exception)
            {
                throw;
            }  
        }
        // #region Adding the user in the database
        // public async Task<bool> AddUser(UserDTO userDTO)
        // {
        //     try
        //     {
        //         if(userDTO==null)
        //         {
        //             return false;
        //         }
        //             User user = UserDTOToUser(userDTO);
        //             context.Users.Add(user);
        //             await context.SaveChangesAsync();
        //             return true;
        //     }
        //     catch(Exception)
        //     {
        //         throw;
        //     }
        // }
        // #endregion 

        public async Task<User> UpdateUser(int userId, UserDTO userDTO)
        {
            try
            {
                //  var converted = UserDTOToUser(user);
                //  var jyou = context.Users.Update(converted);
                var updateUser = await context.Users.FirstOrDefaultAsync(c=>c.UserId == userId);
                if(updateUser!=null)
                {
                    updateUser.UserName=userDTO.UserName;
                    updateUser.EmailId=userDTO.EmailId;
                    updateUser.MobileNumber=userDTO.MobileNumber;
                    updateUser.Dob=userDTO.Dob;
                    updateUser.Gender=userDTO.Gender;
                    updateUser.Role=userDTO.Password;
                    updateUser.Password=userDTO.Password;
                    await context.SaveChangesAsync();
                    return updateUser;
                }
                return null!;
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
                var user = await context.Users.FirstOrDefaultAsync(c=>c.UserId == userId);
                if(user!=null)
                {
                    context.Users.Remove(user);
                    await context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch(Exception)
            {
                throw;
            }
        }
        public User UserDTOToUser(UserDTO userDTO)
        {
            return new User
            {
                UserName=userDTO.UserName,
                Password=userDTO.Password,
                EmailId=userDTO.EmailId,
                MobileNumber=userDTO.MobileNumber,
                Dob=userDTO.Dob,
                Gender=userDTO.Gender,
            };
        }

        public UserDTO UserToUserDTO(User user)
        {
            return new UserDTO
            {
                UserName=user.UserName,
                Password=user.Password,
                EmailId=user.EmailId,
                MobileNumber=user.MobileNumber,
                Dob=user.Dob,
                Gender=user.Gender,
            };
        }
    }
}