using System;
using System.Collections.Generic;
using System.Text;

namespace Review.Domain.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public bool ThumbsUp { get; set; }
        
        public int UserId { get; set; }
        public int CommentId { get; set; }
    }
}
