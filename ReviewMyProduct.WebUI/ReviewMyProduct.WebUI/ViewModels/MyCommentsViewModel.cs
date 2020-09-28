using Review.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewMyProduct.WebUI.ViewModels
{
    public class MyCommentsViewModel
    {
        public ICollection<Product> Products { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
