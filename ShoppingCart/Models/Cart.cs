using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Models;

public class Cart
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CartId { get; set; }

    public int? ProductId { get; set; }

    public int? UserId { get; set; }

    public int? CartValue { get; set; }

    public Product? Product { get; set; }

    public User? User { get; set; }
}
