using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.DTO
{
    public class LoginResponse
    {
        [Required]
        public string? UserName{get;set;}
        [Required]
        public string? Token{get;set;}
        [Required]
        public string? UserId { get; set; }
    
    }
}