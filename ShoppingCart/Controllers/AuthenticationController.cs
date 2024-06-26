using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShoppingCart.DTO;
using ShoppingCart.Models;
using ShoppingCart.Services;

namespace ShoppingCart.Controllers
{
    [ApiController]
    [Route("api/Authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthService Service;

        public AuthenticationController(AuthService _Service)
        {
            Service=_Service;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody]LoginDTO loginDTO)
        {
            string user = Service.Login(loginDTO);
            if(user==null)
            {
                return Unauthorized();
            }
            return Ok(user);
        }

        [HttpPost("RegisterUser")]
        // [AllowAnonymous]
        public IActionResult RegisterUser(UserDTO userDTO)
        {
            UserDTO userResponseDTO = Service.RegisterUser(userDTO);
            if(userResponseDTO==null)
            {
                return Unauthorized();
            }
            return Ok(userResponseDTO);
        }
    }

}