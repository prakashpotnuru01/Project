using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using ShoppingCart.DTO;
using ShoppingCart.Interfaces;
using ShoppingCart.Models;

namespace ShoppingCart.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ShoppingCartDbContext db;

        private readonly IConfiguration config;

        public AuthRepository(ShoppingCartDbContext _db, IConfiguration _config)
        {
            db = _db;
            config= _config;
        }

        public string Login(LoginDTO loginDto)
        {
            User user = db.Users.FirstOrDefault(x => x.UserName == loginDto.UserName )!;
            if(user==null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                return null!;
            }
            var tokenhandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(config["Jwt:SecretKey"]!);
 
            var tokennDescripter = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user!.UserName!),
                    new Claim(ClaimTypes.Role, user.Role!),
                    new Claim(ClaimTypes.GivenName, user.UserName!)
                }),
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(10),
                Issuer = config["Jwt:Issuer"],
                Audience = config["Jwt:Audience"],
 
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
 
            var Mytoken = tokenhandler.CreateToken(tokennDescripter);
            LoginResponse loginResponse = new LoginResponse();
 
            //loginResponse.Token
            string token = tokenhandler.WriteToken(Mytoken);
            loginResponse.UserName = user.UserName!;
            return token;

        }

         public UserDTO RegisterUser(UserDTO userDto)
        {
            User user = UserDTOToUser(userDto);
            User myUser=db.Users.FirstOrDefault(x => x.UserName == user.UserName)!;
            if(myUser==null){
                db.Users.Add(user);
                db.SaveChanges();
                return userDto;
            }
            return null!;
        }
 
        public User UserDTOToUser(UserDTO userDTO){
 
            User user = new User();
            user.Dob = userDTO.Dob;
            user.EmailId = userDTO.EmailId;
            user.MobileNumber = userDTO.MobileNumber;
            user.Gender = userDTO.Gender;
            
            user.UserName = userDTO.UserName;
            user.UserName = userDTO.UserName;
            user.Password = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);
            return user;
        }
    }
}