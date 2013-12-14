using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DYEL.Models;

namespace DYEL.Controllers
{
    public class FitnessLocationController : ApiController
    {
        private DYELContext db = new DYELContext();

        public IEnumerable<FitnessLocation> GetAllLocations()
        {
            return from location in db.FitnessLocations
                   orderby location.Name ascending
                   select location;
        }

        public FitnessLocation GetLocation(Guid fitnessLocationId)
        {
            return db.FitnessLocations.Find(fitnessLocationId);
        }

        public IHttpActionResult PostNewLocation([FromBody]FitnessLocation newLocation)
        {
            if (null != newLocation
                && null != newLocation.Name
                && null != newLocation.Address
                && null != newLocation.Focus)
            {
                newLocation.FitnessLocationId = Guid.NewGuid();
                db.FitnessLocations.Add(newLocation);
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}