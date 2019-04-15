using Review.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewMyProduct.WebUI.ViewModels
{
    public class DetailViewModel
    {
        public Product Product { get; set; }
        public string Description { get; set; }
        public int productId { get; set; }
        // Decide whether to make a single comment variable of attributes of them(description, productId...)
    }
}
