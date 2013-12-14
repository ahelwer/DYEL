using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DYEL.Models
{
    public class Workout
    {
        public Guid WorkoutId { get; set; }
        public String PersonId { get; set; }
        public Guid LocationId { get; set; }
        public DateTime Time { get; set; }
        public String Description { get; set; }
        public String Focus { get; set; }
    }
}