using System;
using System.Collections.Generic;
using System.Text;

namespace Review.Domain.Models
{
    public class Shop
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
