using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DYEL.Models
{
    public class Session
    {
        public Guid SessionId { get; set; }

        public String PersonId { get; set; }

        public DateTime StartTime { get; set; }
    }
}