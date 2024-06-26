using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.DTO
{
    public class CategoryDTO
    {
        [Required]
        public string? CategoryName { get; set; }
    }
}