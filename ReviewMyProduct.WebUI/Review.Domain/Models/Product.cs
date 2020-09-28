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
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string ShopURL { get; set; }

        public ICollection<Comment> Comments { get; set; }  // 4/15 did not add migration yet, to save this, add migration
    }
}
