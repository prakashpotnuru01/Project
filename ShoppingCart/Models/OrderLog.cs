using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Models;

public class OrderLog
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderLogId { get; set; }

    public int? UserId { get; set; }

    public int? PaymentId { get; set; }

    public int? OrderId { get; set; }

    public Order? Order { get; set; }

    public Payment? Payment { get; set; }

    public User? User { get; set; }
}
