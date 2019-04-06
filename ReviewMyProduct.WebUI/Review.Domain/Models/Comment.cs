using System;
using System.Collections.Generic;
using System.Text;

namespace Review.Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }  
        public DateTime WrittenDate { get; set; }
        public string Description { get; set; }

        // this is an ICollection of users' votes on single comment as true(1) or falses(0)
        public ICollection<Rating> Rating { get; set; }     // gets all thumbs up and thumbs down by user for each comment
                                                            // later, display from this Rating ICollection number of trues/falses
                                                                
        public AppUser User { get; set; }
        public string UserId { get; set; } // foreign key

    }
}
