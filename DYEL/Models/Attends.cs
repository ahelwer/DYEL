using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DYEL.Models
{
    public class Attends
    {
        [Key]
        [Column(Order = 0)]
        public String PersonId { get; set; }
        [Key]
        [Column(Order = 1)]
        public Guid LocationId { get; set; }
    }
}