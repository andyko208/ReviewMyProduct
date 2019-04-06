using Microsoft.AspNetCore.Http;
using Review.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewMyProduct.WebUI.ViewModels
{
    public class CreateProductViewModel
    {
        public Product Product { get; set; }
        public IFormFile Image { get; set; }
    }
}
