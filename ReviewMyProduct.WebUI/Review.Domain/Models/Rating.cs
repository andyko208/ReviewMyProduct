﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Review.Domain.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public bool ThumbsUp { get; set; }

        public AppUser User { get; set; }
        public string UserId { get; set; }

        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
