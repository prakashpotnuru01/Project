using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.DTO
{
    public class AddressDTO
    {
        
        public int? UserId { get; set; }
        [Required]
        public int  ? HouseNumber { get; set; }
        [Required]
        public string? StreetName { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? State { get; set; }
        [Required]
        public string? Pincode { get; set; }
    }
}