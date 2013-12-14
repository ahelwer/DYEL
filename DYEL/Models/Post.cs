using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DYEL.Models
{
    public class Post
    {
        public Guid PostId { get; set; }
        public String PersonId { get; set; }
        public DateTime Time { get; set; }
        public String Text { get; set; }
        public String Focus { get; set; }
    }
}