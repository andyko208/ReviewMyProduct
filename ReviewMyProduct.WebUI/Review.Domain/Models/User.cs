﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Review.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Language { get; set; }

        //public int CommentId { get; set; }    // creates cyclical path
        public ICollection<Comment> Comments { get; set; }

        public Rating Rating { get; set; }
    }
}
