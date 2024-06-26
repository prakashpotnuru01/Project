using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.DTO;
using ShoppingCart.Interfaces;

namespace ShoppingCart.Services
{
    public class AuthService
    {
        private readonly IAuthRepository IAuth;

        public AuthService(IAuthRepository _IAuth)
        {
            IAuth=_IAuth;
        }

        public string Login(LoginDTO loginDto)
        {
            try{
                return IAuth.Login(loginDto);
            }
            catch(Exception)
            {
                throw;
            }
            
        }

        public UserDTO RegisterUser(UserDTO userDto)
        {
            try{
                return IAuth.RegisterUser(userDto);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        
    }
}