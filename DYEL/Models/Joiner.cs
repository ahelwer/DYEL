using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DYEL.Models
{
    public enum Response { Pending, Accepted, Rejected };
    public class Joiner
    {
        [Key]
        [Column(Order = 0)]
        public String PersonId { get; set; }
        [Key]
        [Column(Order = 1)]
        public Guid WorkoutId { get; set; }
        public Response Status { get; set; }
    }
}