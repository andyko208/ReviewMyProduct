﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Review.Domain.Models
{
    public class ProductFromShop
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ShopId { get; set; }
    }
}
