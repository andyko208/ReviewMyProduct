using System;
using System.Collections.Generic;
using System.Text;

namespace Review.Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int Good { get; set; }   // To rate the comment
        public int Bad { get; set; }    // To rate the comment
        public string Language { get; set; }        
        public DateTime WrittenDate { get; set; }

        public int UserId { get; set; } // foreign key
        public User User { get; set; }
    }
}
