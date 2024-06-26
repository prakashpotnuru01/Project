using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.DTO;

namespace ShoppingCart.Interfaces
{
    public interface IAuthRepository
    {
        string Login(LoginDTO loginDTO);
        UserDTO RegisterUser(UserDTO userDTO);
    }
}