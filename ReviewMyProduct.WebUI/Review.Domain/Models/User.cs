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
    }
}
