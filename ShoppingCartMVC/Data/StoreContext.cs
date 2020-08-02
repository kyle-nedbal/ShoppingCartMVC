using System;
using Microsoft.EntityFrameworkCore;
using ShoppingCartMVC.Models;

namespace ShoppingCartMVC.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext()
        {

        }

        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
