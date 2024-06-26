using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.DTO
{
    public class ProductDTO
    {
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public string? ProductLink { get; set; }
        [Required]
        public string? ProductDescription { get; set; }
        [Required]
        public decimal? ProductPrice { get; set; }
        [Required]
        public int? ProductQuantity { get; set; }
        
        public int? CategoryId { get; set; }
       
        public int? UserId { get; set; }
    }

}