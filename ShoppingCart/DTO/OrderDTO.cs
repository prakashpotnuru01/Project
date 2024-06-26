using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.DTO
{
    public class OrderDTO
    {
        [Required]
        public int? UserId { get; set; }
        [Required]
        public int? PaymentId { get; set; }
        [Required]
        public int? ProductId { get; set; }
        
    }
}