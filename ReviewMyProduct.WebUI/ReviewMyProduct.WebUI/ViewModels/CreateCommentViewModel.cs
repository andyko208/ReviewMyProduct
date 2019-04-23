using Review.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewMyProduct.WebUI.ViewModels
{
    public class CreateCommentViewModel
    {
        public Product Product { get; set; } // delete out later if Model.Comments doesnt work
        public Comment Comment { get; set; }
        public ICollection<Comment> Comments { get; set; } // to access return dbset of comments for detail.cshtml
        // Decide whether to make a single comment variable of attributes of them(description, productId...)
    }
}
