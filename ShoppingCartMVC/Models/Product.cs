using System;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCartMVC.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public double Price { get; set; }

    }
}
