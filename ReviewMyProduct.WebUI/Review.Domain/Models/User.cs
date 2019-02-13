using System;
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

        public Rating Rating { get; set; }
        public int RatingCount { get; set; }    // To limit how many times user can rate
    }
}
