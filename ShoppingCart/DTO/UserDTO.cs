using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.DTO
{
    public class UserDTO
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set;}
        [Required]
        [EmailAddress]
        public string? EmailId { get; set; }
        [Required]
        public string? MobileNumber { get; set; }
        [Required]
        public DateTime? Dob { get; set; }
        [Required]
        public string? Gender { get; set; }
    }
}