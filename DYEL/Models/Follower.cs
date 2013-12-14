using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DYEL.Models
{
    public class Follower
    {
        [Key]
        [Column(Order = 0)]
        public String FollowerId { get; set; }
        [Key]
        [Column(Order = 1)]
        public String FolloweeId { get; set; }
    }
}