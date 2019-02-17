using System;
using System.Collections.Generic;
using System.Text;

namespace Review.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }

        public int CommentId { get; set; }
        public Comment Comment { get; set; }
        // public ICollection<Shop>  Shops { get; set; }
        public ICollection<ProductFromShop> ProductFromShops { get; set; }
    }
}
