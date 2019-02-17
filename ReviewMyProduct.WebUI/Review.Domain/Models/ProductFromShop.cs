using System;
using System.Collections.Generic;
using System.Text;

namespace Review.Domain.Models
{
    public class ProductFromShop
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}
