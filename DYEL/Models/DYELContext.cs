using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DYEL.Models
{
    public class DYELContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public DYELContext() : base("name=DYELContext")
        {
        }

        public System.Data.Entity.DbSet<DYEL.Models.Person> People { get; set; }

        public System.Data.Entity.DbSet<DYEL.Models.Post> Posts { get; set; }

        public System.Data.Entity.DbSet<DYEL.Models.Comment> Comments { get; set; }

        public System.Data.Entity.DbSet<DYEL.Models.Follower> Followers { get; set; }

        public System.Data.Entity.DbSet<DYEL.Models.Focus> Foci { get; set; }

        public System.Data.Entity.DbSet<DYEL.Models.FitnessLocation> FitnessLocations { get; set; }

        public System.Data.Entity.DbSet<DYEL.Models.Attends> Attends { get; set; }

        public System.Data.Entity.DbSet<DYEL.Models.Workout> Workouts { get; set; }

        public System.Data.Entity.DbSet<DYEL.Models.Joiner> Joiners { get; set; }

        public System.Data.Entity.DbSet<DYEL.Models.Session> Sessions { get; set; }
    
    }
}
