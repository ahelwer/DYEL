using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DYEL.Models
{
    public class FitnessLocation
    {
        public Guid FitnessLocationId { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String Focus { get; set; }
    }
}