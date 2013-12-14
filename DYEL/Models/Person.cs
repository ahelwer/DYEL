using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace DYEL.Models
{
    public enum Gender { Male, Female, Other };
    public class Person
    {
        public String Id { get; set; }
        public String Password { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public String Focus { get; set; }
    }
}