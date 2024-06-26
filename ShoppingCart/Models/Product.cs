using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Models;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? ProductLink { get; set; }

    public string? ProductDescription { get; set; }

    public decimal? ProductPrice { get; set; }

    public int? CategoryId { get; set; }

    public int? ProductQuantity { get; set; }

    public int? UserId { get; set; }

    public Category? Category { get; set; }

    public User? User { get; set; }
}
