using System;
using System.Linq;
using ShoppingCartMVC.Models;

namespace ShoppingCartMVC.Data
{
    public static class DbInitializer
    {
        public static void Initialize(StoreContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Products.Any())
            {
                context.Products.Add(new Product() { Name = "Phone Charger", Price = 29.99 });
                context.Products.Add(new Product() { Name = "Game Console", Price = 349.99 });
                context.Products.Add(new Product() { Name = "Video Game", Price = 59.99 });
                context.Products.Add(new Product() { Name = "TV", Price = 799.99 });
                context.Products.Add(new Product() { Name = "Headphones", Price = 119.99 });
                context.Products.Add(new Product() { Name = "HDMI Cord", Price = 24.99 });
                context.Products.Add(new Product() { Name = "Remote", Price = 49.99 });
                context.Products.Add(new Product() { Name = "Speaker", Price = 199.99 });
                context.SaveChanges();
            }
        }
    }
}
