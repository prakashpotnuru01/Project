using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Models;

public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderId { get; set; }

    public int? UserId { get; set; }

    public int? Quantity { get; set; }

    public decimal? TotalPrice { get; set; }

    public DateOnly? OrderDate { get; set; }

    public bool? OrderStatus { get; set; }

    public int? PaymentId { get; set; }

    public int? ProductId { get; set; }

    public Payment? Payment { get; set; }

    public Product? Product { get; set; }

    public User? User { get; set; }
}
