using System;
using System.Collections.Generic;
using System.Text;

namespace Review.Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Language { get; set; }        
        public DateTime WrittenDate { get; set; }
        public string Description { get; set; }

        public AppUser User { get; set; }
        public string UserId { get; set; } // foreign key
        

    }
}
