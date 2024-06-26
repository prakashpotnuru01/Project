using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Models;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }
    
    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? EmailId { get; set; }

    public string? MobileNumber { get; set; }

    public DateTime? Dob { get; set; }

    public string? Gender { get; set; }

    public string? Role { get; set; }="User";

}
