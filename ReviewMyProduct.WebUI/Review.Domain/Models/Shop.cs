using System;
using System.Collections.Generic;
using System.Text;

namespace Review.Domain.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        // public ICollection<Product> Products { get; set; }
        public ICollection<ProductFromShop> ProductFromShops { get; set; }
    }
}
