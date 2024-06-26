using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Models;

public  class ShoppingCartDbContext : DbContext
{
    public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options): base(options)
    {
        
    }

    public DbSet<Address> Addresses { get; set; }

    public DbSet<Cart> Carts { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderLog> OrderLogs { get; set; }

    public DbSet<Payment> Payments { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<User> Users { get; set; }

}
